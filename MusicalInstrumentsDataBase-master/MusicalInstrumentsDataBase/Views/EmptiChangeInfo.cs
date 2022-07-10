using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using MusicalInstrumentsDataBase.Models.Tables;

namespace Views
{
    internal class EmptiChangeInfo<T> : IChangeInformation<T> where T : DbRow, new()
    {
        public DialogResult Add(DbRowList<T> rows, DbRow[][] sourseTables)
        {
            MessageBox.Show("У вас нет доступа на внесение этого изменения.");
            return DialogResult.No;
        }

        public DialogResult Edit(DbRow row, DbRow[][] sourseTables)
        {
            MessageBox.Show("У вас нет доступа на внесение этого изменения.");
            return DialogResult.No;
        }

        public DialogResult Delete(DbRowList<T> rows, int index)
        {
            MessageBox.Show("У вас нет доступа на внесение этого изменения.");
            return DialogResult.No;
        }
    }
}
