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
    public partial class SupplyMaterialChangeInformation : Form, IChangeInformation<SupplyMaterial>
    {
        SupplyMaterial _initialRow;
        DbRowList<SupplyMaterial> _initialRows;

        public SupplyMaterialChangeInformation()
        {
            InitializeComponent();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(countComboBox.Text, out int count))
            {
                MessageBox.Show("Введены не все данные.");
                return;
            }

            _initialRow.SupplyId = Convert.ToInt32(idSupplyComboBox.Text);
            _initialRow.MaterialId = Convert.ToInt32(idMaterialСomboBox.Text);
            _initialRow.Count = count;

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

        public DialogResult Add(DbRowList<SupplyMaterial> rows, DbRow[][] sourseTables)
        {
            idSupplyComboBox.Enabled = true;
            idMaterialСomboBox.Enabled = true;

            FillID(idSupplyComboBox, sourseTables[0]);
            FillID(idMaterialСomboBox, sourseTables[1]);
            countComboBox.Text = "";

            _initialRow = new SupplyMaterial();

            _initialRows = rows;

            return this.ShowDialog();
        }

        public DialogResult Edit(DbRow row, DbRow[][] sourseTables)
        {
            idSupplyComboBox.Enabled = false;
            idMaterialСomboBox.Enabled = false;

            FillID(idSupplyComboBox, sourseTables[0]);
            FillID(idMaterialСomboBox, sourseTables[1]);

            object[] values = row.GetValues();

            SelectCurrentState(idSupplyComboBox, values[0].ToString());
            SelectCurrentState(idMaterialСomboBox, values[1].ToString());
            countComboBox.Text = values[2].ToString();

            _initialRow = (SupplyMaterial)row;

            return this.ShowDialog();
        }

        public DialogResult Delete(DbRowList<SupplyMaterial> rows, int index)
        {
            rows.RemoveAt(index);
            return DialogResult.OK;
        }

        private void SelectCurrentState(ComboBox cb, string str)
        {
            int i = cb.Items.IndexOf(str);

            if (i >= 0)
            {
                cb.SelectedIndex = i;
            }
        }

        private void FillID(ComboBox cb, DbRow[] sourseRows)
        {
            cb.Items.Clear();

            foreach (DbRow row in sourseRows)
            {
                int i = row.GetPrimaryIndexes()[0];
                cb.Items.Add(row.GetValues()[i].ToString());
            }

            cb.SelectedIndex = 0;
        }
    }
}
