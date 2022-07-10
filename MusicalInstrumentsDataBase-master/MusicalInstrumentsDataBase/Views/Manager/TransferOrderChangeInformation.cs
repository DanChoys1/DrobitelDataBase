using Database;
using MusicalInstrumentsDataBase.Models.Tables;

namespace Views
{
    public partial class TransferOrderChangeInformation : Form, IChangeInformation<TransferOrder>
    {
        TransferOrder _initialRow;
        DbRowList<TransferOrder> _initialRows;

        bool isAdd = false;

        public TransferOrderChangeInformation()
        {
            InitializeComponent();

            stateComboBox.Items.Add("Открыт");
            stateComboBox.Items.Add("Закрыт");
            stateComboBox.SelectedIndex = 0;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!isCorrectDate(dateComboBox.Text))
            {
                MessageBox.Show("Введены не корректные данные.");
                return;
            }

            if (isAdd)
            {
                _initialRows.Procedure = $"CALL `создать_заказ_перемещения`({idRouteСomboBox.Text})";
            }
            else
            {
                _initialRow.OrderID = Convert.ToInt32(idOrderComboBox.Text);
                _initialRow.RouteID = Convert.ToInt32(idRouteСomboBox.Text);
                _initialRow.Status = stateComboBox.Text;
                _initialRow.Date = dateComboBox.Text;

                if (_initialRows != null)
                {
                    _initialRows.Add(_initialRow);
                    _initialRows = null;
                }
            }                

            DialogResult = DialogResult.OK;
            this.Hide();

        }

        private string ParseDate(string str)
        {
            if (str == "") return "";
            return str.Substring(6, 4) + "." + str.Substring(3, 3) + str.Substring(0, 2);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _initialRows = null;
            DialogResult = DialogResult.No;
            this.Hide();
        }

        public DialogResult Add(DbRowList<TransferOrder> rows, DbRow[][] sourseTables)
        {
            isAdd = true;

            dateComboBox.Enabled = false;
            stateComboBox.Enabled = false;
            stateComboBox.SelectedIndex = 0;

            FillIDRoutes(sourseTables[0]);

            idOrderComboBox.Text = "0";
            stateComboBox.Text = "Открыт";
            dateComboBox.Text = "";

            _initialRow = new TransferOrder();

            _initialRows = rows;

            return this.ShowDialog();
        }

        public DialogResult Edit(DbRow row, DbRow[][] sourseTables)
        {
            isAdd = false; 

            stateComboBox.Enabled = true;
            dateComboBox.Enabled = true;

            FillIDRoutes(sourseTables[0]);

            object[] values = row.GetValues();

            idOrderComboBox.Text = values[0].ToString();
            idRouteСomboBox.Text = values[1].ToString();
            SelectCurrentState(values[2].ToString());
            dateComboBox.Text = ParseDate(values[3].ToString());

            _initialRow = (TransferOrder)row;

            return this.ShowDialog();
        }

        public DialogResult Delete(DbRowList<TransferOrder> rows, int index)
        {
            rows.RemoveAt(index);
            return DialogResult.OK;
        }

        private void SelectCurrentState(string str)
        {
            int i = stateComboBox.Items.IndexOf(str);

            if (i >= 0)
            {
                stateComboBox.SelectedIndex = i;
            }
        }

        private void FillIDRoutes(DbRow[] sourseRows)
        {
            idRouteСomboBox.Items.Clear();

            foreach (DbRow row in sourseRows)
            {
                int i = row.GetPrimaryIndexes()[0];
                idRouteСomboBox.Items.Add(row.GetValues()[i].ToString());  
            }

            idRouteСomboBox.SelectedIndex = 0;
        }

        private bool isCorrectDate(string date)
        {
            bool isCorrectDate = true;

            if (date == "")
            {
                return true;
            }

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    isCorrectDate &= Char.IsDigit(date[i]);
                }

                isCorrectDate &= date[4] == '.';

                for (int i = 5; i < 7; i++)
                {
                    isCorrectDate &= Char.IsDigit(date[i]);
                }

                isCorrectDate &= date[7] == '.';

                for (int i = 8; i < 10; i++)
                {
                    isCorrectDate &= Char.IsDigit(date[i]);
                }
            }
            catch (Exception)
            {
                isCorrectDate = false;
            }

            return isCorrectDate;
        }
    }
}
