using Presenters;

namespace Views
{
    public partial class EmployeeSelection : Form, IEmployeeSelection
    {
        public event EventHandler ManagerChoiceEvent;

        public EmployeeSelection()
        {
            InitializeComponent();

            new EmployeeSelectionPresenter(this);
        }

        private void managerChoiceButton_Click(object sender, EventArgs e)
        {
            ManagerChoiceEvent.Invoke(sender, e);
        }
    }
}