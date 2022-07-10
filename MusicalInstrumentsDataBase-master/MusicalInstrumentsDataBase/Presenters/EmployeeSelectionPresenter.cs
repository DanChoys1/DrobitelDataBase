using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;

namespace Presenters
{
    internal class EmployeeSelectionPresenter
    {
        private readonly IEmployeeSelection _employeeSelectionView;
        private readonly IManager _manager;

        public EmployeeSelectionPresenter(IEmployeeSelection employeeSelectionView)
        {
            _employeeSelectionView = employeeSelectionView;

            _employeeSelectionView.ManagerChoiceEvent += ShowManagerViews;

            _manager = new DataTables();
        }

        private void ShowManagerViews(object sender, EventArgs e)
        {
            _manager.ShowView();
        }
    }
}
