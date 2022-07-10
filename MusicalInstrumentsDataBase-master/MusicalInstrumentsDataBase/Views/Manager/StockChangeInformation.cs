using Database;
using MusicalInstrumentsDataBase.Models.Tables;

namespace Views
{
    public partial class StockChangeInformation : Form, IChangeInformation<Stock>
    {
        Stock _initialRow;
        DbRowList<Stock> _initialRows;

        public StockChangeInformation()
        {
            InitializeComponent();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (adressСomboBox.Text == "" || phoneComboBox.Text == "")
            {
                MessageBox.Show("Введены не все данные.");
                return;
            }

            _initialRow.Id = Convert.ToInt32(idScladaComboBox.Text);
            _initialRow.Addres = adressСomboBox.Text.ToString();
            _initialRow.Phone = phoneComboBox.Text.ToString();

            if (_initialRows != null)
            {
                _initialRows.Add(_initialRow);
                _initialRows = null;
            }

            DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _initialRows = null;
            DialogResult = DialogResult.No;
            this.Hide();
        }

        public DialogResult Add(DbRowList<Stock> rows, DbRow[][] sourseTables)
        {
            idScladaComboBox.Text = "0";
            adressСomboBox.Text = "";
            phoneComboBox.Text = "";

            _initialRow = new Stock();

            _initialRows = rows;

            return this.ShowDialog();
        }
            
        public DialogResult Edit(DbRow row, DbRow[][] sourseTables)
        {
            object[] values = row.GetValues();

            idScladaComboBox.Text = values[0].ToString();
            adressСomboBox.Text = values[1].ToString();
            phoneComboBox.Text = values[2].ToString();

            _initialRow = (Stock)row;

            return this.ShowDialog();
        }

        public DialogResult Delete(DbRowList<Stock> rows, int index)
        {
            rows.RemoveAt(index);
            return DialogResult.OK;
        }

        private string correctText(string text)
        {
            if (text == "")
            {
                return "";
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsDigit(text[i]))
                {
                    text = text.Remove(i, 1);
                    i--;
                }
            }

            if (Convert.ToInt32(text) < 0)
            {
                text.Remove(0, 1);
            }

            return text;
        }

        private void adressСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = adressСomboBox.SelectedIndex;

            adressСomboBox.Text = correctText(idScladaComboBox.Text);

            adressСomboBox.SelectedIndex = pos;
        }

        private void phoneComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = phoneComboBox.SelectedIndex;

            phoneComboBox.Text = correctText(idScladaComboBox.Text);

            phoneComboBox.SelectedIndex = pos;
        }
    }
}
