using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;
using MusicalInstrumentsDataBase.Models.Tables;

namespace Views
{
    public partial class SupplyChangeInformation : Form, IChangeInformation<Supply>
    {
        Supply _initialRow;
        DbRowList<Supply> _initialRows;

        public SupplyChangeInformation()
        {
            InitializeComponent();

            stateComboBox.Items.Add("Отгружается");
            stateComboBox.Items.Add("В пути");
            stateComboBox.Items.Add("Доставлен");
            stateComboBox.Items.Add("Задерживается");
            stateComboBox.SelectedIndex = 0;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!isCorrectDate(outDateComboBox.Text) || !isCorrectDate(inDateComboBox.Text))
            {
                MessageBox.Show("Введены не корректные данные.");
                return;
            }

            _initialRow.ID = Convert.ToInt32(idSupplyComboBox.Text);
            _initialRow.TransferOrderID = Convert.ToInt32(idOrderСomboBox.Text);
            _initialRow.Status = stateComboBox.Text;
            _initialRow.inDate = inDateComboBox.Text != "" ? inDateComboBox.Text : null;
            _initialRow.outDate = outDateComboBox.Text != "" ? outDateComboBox.Text : null;

            if (_initialRows != null)
            {
                _initialRows.Add(_initialRow);
                _initialRows = null;
            }

            DialogResult = DialogResult.OK;
            this.Hide();
        }

        private string ParseDate(string str)
        {
            if (str == "") return "";
            return str.Substring(6, 4) + "." + str.Substring(3, 3) + str.Substring(0, 2) + str.Substring(10);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _initialRows = null;
            DialogResult = DialogResult.No;
            this.Hide();
        }

        public DialogResult Add(DbRowList<Supply> rows, DbRow[][] sourseTables)
        {
            idSupplyComboBox.Text = "0";
            outDateComboBox.Text = "";
            inDateComboBox.Text = "";

            FillIDOrders(sourseTables[0]);

            _initialRow = new Supply();

            _initialRows = rows;

            return this.ShowDialog();
        }

        public DialogResult Edit(DbRow row, DbRow[][] sourseTables)
        {
            object[] values = row.GetValues();

            idSupplyComboBox.Text = values[0].ToString();
            FillIDOrders(sourseTables[0]);
            SelectCurrentState(values[1].ToString());
            stateComboBox.Text = values[2].ToString();
            outDateComboBox.Text = values[3] == null ? "" : ParseDate(values[3].ToString());
            inDateComboBox.Text = values[4] == null ? "" : ParseDate(values[4].ToString());

            _initialRow = (Supply)row;

            return this.ShowDialog();
        }

        private void SelectCurrentState(string str)
        {
            int i = idOrderСomboBox.Items.IndexOf(str);

            if (i >= 0)
            {
                idOrderСomboBox.SelectedIndex = i;
            }
        }

        public DialogResult Delete(DbRowList<Supply> rows, int index)
        {
            rows.RemoveAt(index);
            return DialogResult.OK;
        }

        private void FillIDOrders(DbRow[] sourseRows)
        {
            idOrderСomboBox.Items.Clear();

            foreach (DbRow row in sourseRows)
            {
                int i = row.GetPrimaryIndexes()[0];
                idOrderСomboBox.Items.Add(row.GetValues()[i].ToString());
            }

            idOrderСomboBox.SelectedIndex = 0;
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

                isCorrectDate &= date[10] == ' ';

                for (int i = 11; i < 13; i++)
                {
                    isCorrectDate &= Char.IsDigit(date[i]);
                }

                isCorrectDate &= date[13] == ':';

                for (int i = 14; i < 16; i++)
                {
                    isCorrectDate &= Char.IsDigit(date[i]);
                }

                isCorrectDate &= date[16] == ':';

                for (int i = 17; i < 19; i++)
                {
                    isCorrectDate &= Char.IsDigit(date[i]);
                }
            }
            catch (Exception )
            {
                isCorrectDate = false;
            }

            return isCorrectDate;
        }
    }
}
