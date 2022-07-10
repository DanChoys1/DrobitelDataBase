using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;

namespace Views
{
    internal interface IChangeInformation<T> where T : DbRow, new()
    {
        DialogResult Add(DbRowList<T> rows, DbRow[][] sourseTables);

        DialogResult Edit(DbRow row, DbRow[][] sourseTables);

        DialogResult Delete(DbRowList<T> rows, int index);
    }
}
