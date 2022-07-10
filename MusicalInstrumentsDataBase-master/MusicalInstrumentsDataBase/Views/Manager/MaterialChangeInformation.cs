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
    public partial class MaterialChangeInformation : Form, IChangeInformation<Material>
    {
        Material _initialRow;
        DbRowList<Material> _initialRows;

        public MaterialChangeInformation()
        {
            InitializeComponent();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (nameComboBox.Text == "")
            {
                MessageBox.Show("Введены не все данные.");
                return;
            }

            _initialRow.Id = Convert.ToInt32(idComboBox.Text);
            _initialRow.Name = nameComboBox.Text.ToString();

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

        public DialogResult Add(DbRowList<Material> rows, DbRow[][] sourseTables)
        {
            idComboBox.Text = "0";
            nameComboBox.Text = "";

            _initialRow = new Material();

            _initialRows = rows;

            return this.ShowDialog();
        }

        public DialogResult Edit(DbRow row, DbRow[][] sourseTables)
        {
            object[] values = row.GetValues();

            idComboBox.Text = values[0].ToString();
            nameComboBox.Text = values[1].ToString();

            _initialRow = (Material)row;

            return this.ShowDialog();
        }

        public DialogResult Delete(DbRowList<Material> rows, int index)
        {
            rows.RemoveAt(index);
            return DialogResult.OK;
        }
    }
}
