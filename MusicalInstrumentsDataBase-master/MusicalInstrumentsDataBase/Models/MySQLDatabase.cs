using MySql.Data.MySqlClient;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

namespace Database
{
    #region DbRowList

    public class DbRowList<T> where T : DbRow, new()
    {
        public readonly string TableName;
        public readonly bool IsTmp;

        public readonly string AddProcedure;
        public string Procedure { get; set; }

        private readonly List<T> _addedRows;
        private readonly List<T> _removedRows;
        private readonly List<T> _initialRows;
        private List<T> _rows;

        private readonly List<int> _autoIncrementPropertyIndexes;
        private readonly int[] _autoIncrementValues;

        public enum Change
        {
            Add,
            Edit,
            Delete
        }

        public DbRowList(string tableName, string addProcedure = "")
        {
            TableName = tableName;

            AddProcedure = addProcedure;
            Procedure = "";

            IsTmp = AddProcedure != "" ? true : false;

            _addedRows = new List<T>();
            _removedRows = new List<T>();
            _initialRows = new List<T>();
            _rows = new List<T>();

            DbRow dbRow = new T();
            _autoIncrementPropertyIndexes = dbRow.GetAutoIncrementIndexes();
            _autoIncrementValues = new int[_autoIncrementPropertyIndexes.Count];

            for (int i = 0; i < _autoIncrementValues.Length; i++)
            {
                _autoIncrementValues[i] = -1;
            }
        }

        public T this[int index]
        {
            get => _rows[index];
        }

        public void DbInitialRows(List<T> rows)
        {
            _rows = rows;

            _initialRows.Clear();
            _addedRows.Clear();
            _removedRows.Clear();

            foreach (T row in _rows)
            {
                T copyRow = new T();
                row.CopyTo(copyRow);

                _initialRows.Add(copyRow);

                object[] values = row.GetValues();

                foreach (int index in _autoIncrementPropertyIndexes)
                {
                    if ((int)values[index] <= _autoIncrementValues[index])
                    {
                        values[index] = _autoIncrementValues[index] + 1;
                    }

                    _autoIncrementValues[index] = (int)values[index];
                }
            }
        }

        public void Add(T row)
        {
            _rows.Add(row);
            _addedRows.Add(row);

            object[] values = row.GetValues();

            foreach (int index in _autoIncrementPropertyIndexes)
            {
                if ((int)values[index] <= _autoIncrementValues[index])
                {
                    values[index] = _autoIncrementValues[index] + 1;
                    row.Fill(values);
                }

                _autoIncrementValues[index] = (int)values[index];
            }
        }

        public void Add(object[] values)
        {
            T row = new T();
            _rows.Add(row);
            _addedRows.Add(row);

            foreach (int index in _autoIncrementPropertyIndexes)
            {
                if ((int)values[index] <= _autoIncrementValues[index])
                {
                    values[index] = _autoIncrementValues[index] + 1;
                    
                }

                _autoIncrementValues[index] = (int)values[index];
            }

            row.Fill(values);
        }

        public void RemoveAt(int i)
        {
            if (!_addedRows.Contains(_rows[i]))
            {
                _removedRows.Add(_rows[i]);
            }

            _addedRows.Remove(_rows[i]);
            _rows.RemoveAt(i);
        }

        public void Remove(T row)
        {
            if (!_addedRows.Contains(row))
            {
                _removedRows.Add(row);
            }

            _addedRows.Remove(row);
            _rows.Remove(row);
        }

        public Dictionary<Change, List<T>> GetChanges()
        {
            Dictionary<Change, List<T>> rows = new Dictionary<Change, List<T>>()
            {
                { Change.Add, new List<T>(_addedRows) },
                { Change.Edit, new List<T>(GetEditedRows()) },
                { Change.Delete, new List<T>(_removedRows) }
            };

            return rows;
        }

        public List<T> GetAddedRows() => _addedRows;

        public List<T> GetRemovedRows() => _removedRows;

        public List<T> GetRows() => _rows;

        public List<T> GetEditedRows()
        {
            List<T> changeRows = new List<T>();

            for (int j = 0; j < _initialRows.Count; j++)
            {
                for (int i = 0; i < _rows.Count; i++)
                {
                    if (_rows[i].Equals(_initialRows[j]))
                    {
                        break;
                    }
                    else if (_rows[i].Same(_initialRows[j]))
                    {
                        changeRows.Add(_rows[i]);
                        break;
                    }
                }
            }

            return changeRows;
        }

        public bool IsChanged()
        {
            Dictionary<Change, List<T>> rows = GetChanges();

            bool isChanged = GetAddedRows().Count > 0;
            isChanged |= GetRemovedRows().Count > 0;
            isChanged |= GetEditedRows().Count > 0;
            isChanged |= Procedure != "";

            return isChanged;
        }

        public void ClearChanges()
        {
            _addedRows.Clear();
            _removedRows.Clear();
            _initialRows.Clear();
            Procedure = "";

            foreach (T row in _rows)
            {
                T copyRow = new T();
                row.CopyTo(copyRow);

                _initialRows.Add(copyRow);
            }
        }

        public IEnumerator GetEnumerator() => _rows.GetEnumerator();
    }

    #endregion DbRowList

    #region MySqlDatabase
    internal class MySqlDatabase : IDisposable
    {
        private readonly MySqlConnection connection;

        public MySqlDatabase(string database, string host, string user, string password)
        {
            string connectData = "Database=" + database + ";Datasource=" + host + ";User=" + user + ";Password=" + password;
            connection = new MySqlConnection(connectData);
            connection.OpenAsync().Wait();
        }

        public void InitialRows<T>(DbRowList<T> initialRows) where T : DbRow, new()
        {
            if (initialRows.IsTmp)
            {
                MySqlCommand createTmp = new MySqlCommand($"CALL `{initialRows.AddProcedure}`();", connection);
                createTmp.ExecuteNonQuery();
            }

            MySqlCommand readTableQuery = new MySqlCommand($"SELECT * FROM `{initialRows.TableName}`", connection);
            using MySqlDataReader table = readTableQuery.ExecuteReader();

            if (!table.HasRows)
            {
                return;
            }

            List<T> readRows = new List<T>();

            while (table.Read())
            {
                object[] values = new object[table.FieldCount];
                table.GetValues(values);

                T row = new T();
                row.Fill(values);
                readRows.Add(row);
            }

            initialRows.DbInitialRows(readRows);

            if (initialRows.IsTmp)
            {
                table.Dispose();

                MySqlCommand dropTmp = new MySqlCommand($"DROP TEMPORARY TABLE `{initialRows.TableName}`;", connection);
                dropTmp.ExecuteNonQuery();
            }
        }

        public void SaveChanges<T>(DbRowList<T> rows) where T : DbRow, new()
        {
            Dictionary<DbRowList<T>.Change, List<T>> canges = rows.GetChanges();

            string commandText = AddRowCommand(canges[DbRowList<T>.Change.Add], rows.TableName) + Environment.NewLine;
            commandText += DeleteRowCommand(canges[DbRowList<T>.Change.Delete], rows.TableName) + Environment.NewLine;
            commandText += UpdateRowCommand(canges[DbRowList<T>.Change.Edit], rows.TableName);
            commandText += rows.Procedure;

            MySqlCommand query = new MySqlCommand(commandText, connection);
            query.ExecuteNonQuery();

            rows.ClearChanges();
        }

        public async Task SaveChangesAsync<T>(DbRowList<T> rows) where T : DbRow, new()
        {
            Dictionary<DbRowList<T>.Change, List<T>> canges = rows.GetChanges();

            string commandText = AddRowCommand(canges[DbRowList<T>.Change.Add], rows.TableName) + Environment.NewLine;
            commandText += DeleteRowCommand(canges[DbRowList<T>.Change.Delete], rows.TableName) + Environment.NewLine;
            commandText += UpdateRowCommand(canges[DbRowList<T>.Change.Edit], rows.TableName);

            MySqlCommand query = new MySqlCommand(commandText, connection);
            await query.ExecuteNonQueryAsync();

            rows.ClearChanges();
        }

        private string UpdateRowCommand<T>(List<T> rows, string tableName) where T : DbRow, new()
        {
            MySqlCommand readTableQuery = new MySqlCommand($"SELECT * FROM `{tableName}`", connection);
            using MySqlDataReader table = readTableQuery.ExecuteReader();

            string command = "";

            foreach (T row in rows)
            {
                command += $"UPDATE `{tableName}` SET ";

                object[] values = row.GetValues();
                List<int> primaryIndexes = row.GetPrimaryIndexes();

                for (int i = 0; i < values.Length; i++)
                {
                    string tName = table.GetName(i) != null ? $"`{table.GetName(i)}`" : "null";
                    string val = values[i] != null ? $"'{values[i]}'" : "null";

                    command += tName + "=" + val + ", ";
                }

                command = command.Remove(command.Length - 2, 1) + "WHERE ";

                for (int i = 0; i < primaryIndexes.Count; i++)
                {
                    string tName = table.GetName(i) != null ? $"`{table.GetName(i)}`" : "null";
                    string val = values[i] != null ? $"'{values[i]}'" : "null";

                    command += tName + "=" + val + " AND ";
                }

                command = command.Remove(command.Length - 5) + ";" + Environment.NewLine;
            }

            return command;
        }

        public static string AddRowCommand<T>(List<T> rows, string tableName) where T : DbRow, new()
        {
            string command = "";

            foreach (T row in rows)
            {
                object[] values = row.GetValues();

                command += $"INSERT INTO `{tableName}` VALUES (";

                for (int i = 0; i < values.Length; i++)
                {
                    string val = values[i] != null ? $"'{values[i]}'" : "null";

                    command += val + ", ";
                }

                command = command.Remove(command.Length - 2) + ");" + Environment.NewLine;
            }

            return command;
        }

        public string DeleteRowCommand<T>(List<T> rows, string tableName) where T : DbRow, new()
        {
            string command = "";

            MySqlCommand readTableQuery = new MySqlCommand($"SELECT * FROM `{tableName}`", connection);
            using MySqlDataReader table = readTableQuery.ExecuteReader();

            foreach (T row in rows)
            {
                object[] values = row.GetValues();
                List<int> primaryIndexes = row.GetPrimaryIndexes();

                command += $"DELETE FROM `{tableName}` WHERE ";

                for (int i = 0; i < primaryIndexes.Count; i++)
                {
                    string tName = table.GetName(i) != null ? $"`{table.GetName(i)}`" : "null";
                    string val = values[i] != null ? $"'{values[i]}'" : "null";

                    command += tName + "=" + val + " AND ";
                }

                command = command.Remove(command.Length - 5) + ";" + Environment.NewLine;
            }

            return command;
        }

        public void Dispose()
        {
            connection.CloseAsync();

            GC.SuppressFinalize(this);
        }
    }

    #endregion SQLiteDatabase

    #region DbRow

    public class DbRow
    {
        public void Fill(object[] values)
        {
            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            int minCountValues = Math.Min(properties.Length, values.Length);

            for (int i = 0; i < minCountValues; i++)
            {
                if (values[i] == null)
                {
                    properties[i].SetValue(this, values[i]);
                }
                else if (properties[i].PropertyType == values[i].GetType())
                {
                    properties[i].SetValue(this, values[i]); 
                }
                else if (properties[i].PropertyType == typeof(string))
                {
                    properties[i].SetValue(this, values[i].ToString());
                }
            }
        }

        public object[] GetValues()
        {
            PropertyInfo[] propertys = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            object[] values = new object[propertys.Length];

            for (int i = 0; i < propertys.Length; i++)
            {
                values[i] = propertys[i].GetValue(this);
            }

            return values;
        }

/*        public object[] GetJoinedValues(DbRow[][] joinedRows)
        {
            object[] values = this.GetValues();

            *//*PropertyInfo[] propertys = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < propertys.Length; i++)
            {
                Attribute? attribute = propertys[i].GetCustomAttribute(typeof(JoinedAttribute));

                if (attribute != null)
                {
                    JoinedAttribute joine = (JoinedAttribute)attribute;
                    DbRow joineRow = joinedRows.Last( val => val.Same(joine.FromTypeRow) );
                    values[i] = joineRow.GetName();
                }
            }*//*

            return values;
        }*/

/*        public object GetName()
        {
            PropertyInfo[] propertys = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in propertys)
            {
                Attribute? attribute = property.GetCustomAttribute(typeof(NameAttribute));

                if (attribute != null)
                {
                    return property.GetValue(this);
                }
            }

            return null;
        }*/

        public List<int> GetPrimaryIndexes()
        {
            List<int> indexes = new List<int>();

            PropertyInfo[] propertys = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < propertys.Length; i++)
            {
                Attribute? attribute = propertys[i].GetCustomAttribute(typeof(PrimaryAttribute));

                if (attribute != null)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        public List<int> GetAutoIncrementIndexes()
        {
            List<int> autoIncrementPropertys = new List<int>();

            PropertyInfo[] propertys = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < propertys.Length; i++)
            {
                if (propertys[i].PropertyType != typeof(int))
                {
                    continue;
                }

                Attribute? attribute = propertys[i].GetCustomAttribute(typeof(AutoIncrementAttribute));

                if (attribute != null)
                {
                    autoIncrementPropertys.Add(i);
                }
            }

            return autoIncrementPropertys;
        }

        /// <summary>
        /// Проверяет является ли объект той же строкой по уникальным ключам.
        /// </summary>
        public bool Same(DbRow row)
        {
            if (this.GetType() != row.GetType())
            {
                return false;
            }

            bool isEqual = false;

            PropertyInfo[] property = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<int> primaryIndexes = GetPrimaryIndexes();

            foreach (int index in primaryIndexes)
            {
                if (property[index].GetValue(this).ToString() == property[index].GetValue(row).ToString())
                {
                    isEqual = true;
                }
                else
                {
                    isEqual = false;
                    break;
                }
            }

            return isEqual;
        }

        public override bool Equals(object row)
        {
            if (this.GetType() != row.GetType())
            {
                return false;
            }

            bool isEqual = false;

            foreach (PropertyInfo property in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                object val1 = property.GetValue(this);
                object val2 = property.GetValue(row);

                if (val1 == null && val2 == null)
                {
                    isEqual = true;
                }
                else if (val1 == null || val2 == null)
                {
                    isEqual = false;
                    break;
                }
                else if (val1.Equals(val2))
                {
                    isEqual = true;
                }
                else
                {
                    isEqual = false;
                    break;
                }
            }

            return isEqual;
        }

        public void CopyTo(DbRow row)
        {
            foreach (PropertyInfo property in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                property.SetValue(row, property.GetValue(this));
            }
        }
    }

    #endregion DbRow

    #region Attributes

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryAttribute : Attribute
    {
    }

    // INotifyPropertyChanged
    // ReactiveUI, Fody - библиотеки
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoIncrementAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class JoinedAttribute : Attribute
    {
        public Type FromTypeRow { get; private set; }

        public JoinedAttribute(Type fromRow) 
        {
            FromTypeRow = fromRow;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NameAttribute : Attribute
    {
    }

    //Roslyn, introduction

    #endregion Attributes
}
