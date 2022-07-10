using Presenters;
using MusicalInstrumentsDataBase.Models;

namespace Views
{
    public partial class DataTables : Form, IManager
    {
        public event EventHandler UpdateEvent;

        public DataGridView DataGridView 
        { 
            get { return dataGridView; }
        }

        public DataTables()
        {
            InitializeComponent();

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.RowHeadersVisible = false;

            dataGridView.ColumnCount = 13;
            dataGridView.Columns[0].HeaderText = "Название дробилки";
            dataGridView.Columns[1].HeaderText = "Стоимость";
            dataGridView.Columns[2].HeaderText = "Мощность";
            dataGridView.Columns[3].HeaderText = "Макс. размер питания";
            dataGridView.Columns[4].HeaderText = "Производительность";
            dataGridView.Columns[5].HeaderText = "Масса";
            dataGridView.Columns[6].HeaderText = "Кол-во двигателей";
            dataGridView.Columns[7].HeaderText = "Оценка";
            dataGridView.Columns[8].HeaderText = "Страна";
            dataGridView.Columns[9].HeaderText = "Тип";
            dataGridView.Columns[10].HeaderText = "Длина";
            dataGridView.Columns[11].HeaderText = "Ширина";
            dataGridView.Columns[12].HeaderText = "Высота";

            ManagerPresenter managerPresenter = new ManagerPresenter(this);

            CheckBox[] checkBox = Sample.GetCheckBoxes();

            for (int i = 0; i < checkBox.Count(); i++)
            {
                panel1.Controls.Add(checkBox[i]);
            }
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            UpdateEvent.Invoke(sender, e);
        }
    }
}
