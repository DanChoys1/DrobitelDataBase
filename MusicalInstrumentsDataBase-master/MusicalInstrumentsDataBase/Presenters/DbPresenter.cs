using Database;
using Views;

namespace MusicalInstrumentsDataBase.Presenters
{
    internal class DbPresenter <T> : IDbPresenter where T : DbRow, new()
    {
        private readonly IManager _manager;
        private IChangeInformation<T> _interactionInformation;

        private readonly MySqlDatabase _database;

        private readonly DbRowList<T> _dbRows;
        private DbRow[][] _tables;

        public DbPresenter(IManager view, IChangeInformation<T> interactionInformation, MySqlDatabase database, DbRowList<T> dbRows)
        {
            _manager = view;
            _interactionInformation = interactionInformation;

            _database = database;

            _dbRows = dbRows;
        }

        private void UpdateDataGridView(object sender, EventArgs e)
        {
            if (_dbRows.IsChanged())
            {
                DialogResult res = MessageBox.Show("Изменения не были сохранены. Продолжить?",
                                                        "Сообщение", MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                {
                    return;
                }
            }

            _database.InitialRows(_dbRows);

            FillDataGridView();
        }

        private void FillDataGridView()
        {
            _manager.DataGridView.Rows.Clear();

            foreach (DbRow row in _dbRows.GetRows())
            {
                _manager.DataGridView.Rows.Add(row.GetValues());
            }
        }

        private void AddRecord(object sender, EventArgs e)
        {
            DialogResult result = _interactionInformation.Add(_dbRows, _tables);
            
            if (result == DialogResult.OK)
            {
                FillDataGridView();
            }
        }

        private void DeleteRecord(object sender, EventArgs e)
        {
            _interactionInformation.Delete(_dbRows, _manager.DataGridView.SelectedRows[0].Index);
            FillDataGridView();
        }

        private void EditRecord(object sender, EventArgs e)
        {
            int selectRowIndex = _manager.DataGridView.SelectedRows[0].Index;

            DialogResult result = _interactionInformation.Edit(_dbRows[selectRowIndex], _tables);

            if (result == DialogResult.OK)
            {
                FillDataGridView();
            }
        }

        private void SaveToDb(object sender, EventArgs e)
        {
            if (_dbRows.IsChanged())
            {
                try
                {
                    _database.SaveChanges(_dbRows);
                    UpdateDataGridView(sender, e);
                }
                catch (Exception )
                {
                    //MessageBox.Show("Ошибка операции.", "Ошибка");
                }
            }
        }

        public bool IsSaved()
        {
            return !_dbRows.IsChanged();
        }

        public void SetSourseTables(params DbRow[][] soursRows)
        {
            _tables = new DbRow[soursRows.Length][];

            for (int i = 0; i < soursRows.Length; i++)
            {
                _tables[i] = soursRows[i];
            }
        }

        public void Connect()
        {
            _manager.UpdateEvent += UpdateDataGridView;
            _manager.AddEvent += AddRecord;
            _manager.DeleteEvent += DeleteRecord;
            _manager.EditEvent += EditRecord;
            _manager.SaveDataToDbEvent += SaveToDb;

            UpdateDataGridView(this, new EventArgs());
        }

        public void Disconnect()
        {
            _manager.UpdateEvent -= UpdateDataGridView;
            _manager.AddEvent -= AddRecord;
            _manager.DeleteEvent -= DeleteRecord;
            _manager.EditEvent -= EditRecord;
            _manager.SaveDataToDbEvent -= SaveToDb;
        }
    }
}
