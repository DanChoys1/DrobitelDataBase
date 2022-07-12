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

            dataGridView.ColumnCount = 12;
            dataGridView.Columns[0].HeaderText = "Название дробилки";
            dataGridView.Columns[1].HeaderText = "Стоимость (руб)";
            dataGridView.Columns[2].HeaderText = "Мощность (кВт)";
            dataGridView.Columns[3].HeaderText = "Макс. размер питания (мм)";
            dataGridView.Columns[4].HeaderText = "Производительность (т/ч)";
            dataGridView.Columns[5].HeaderText = "Масса (кг)";
            dataGridView.Columns[6].HeaderText = "Кол-во двигателей";
            dataGridView.Columns[7].HeaderText = "Страна";
            dataGridView.Columns[8].HeaderText = "Тип";
            dataGridView.Columns[9].HeaderText = "Длина (мм)";
            dataGridView.Columns[10].HeaderText = "Ширина (мм)";
            dataGridView.Columns[11].HeaderText = "Высота (мм)";

            Sample.coastStartNumericUpDown = coastStartNumericUpDown;
            Sample.coastEndNumericUpDown = coastEndNumericUpDown;

            Sample.powerStartNumericUpDown = powerStartNumericUpDown;
            Sample.powerEndNumericUpDown = powerEndNumericUpDown;

            Sample.maxSizeStartNumericUpDown = maxSizeStartNumericUpDown;
            Sample.maxSizeEndNumericUpDown = maxSizeEndNumericUpDown;

            Sample.performanceStartNumericUpDown = performanceStartNumericUpDown;
            Sample.performancEndNumericUpDown = performanceEndNumericUpDown;
           
            Sample.massStartNumericUpDown = massStartNumericUpDown;
            Sample.massEndNumericUpDown = massEndNumericUpDown;
            
            Sample.numberEnginesStartNumericUpDown = numberEnginesStartNumericUpDown;
            Sample.numberEnginesEndNumericUpDown = numberEnginesEndNumericUpDown;

            Sample.stateСheckedListBox = stateСheckedListBox;
            Sample.typeСheckedListBox = typeCheckedListBox;
            
            Sample.lengthStartNumericUpDown = lengthStartNumericUpDown;
            Sample.lengthEndNumericUpDown = lengthEndТumericUpDown;
            
            Sample.widthStartNumericUpDown = widthStartNumericUpDown;
            Sample.widthEndNumericUpDown = widthEndNumericUpDown;
            
            Sample.hightStartNumericUpDown = hightStartNumericUpDown;
            Sample.hightEndNumericUpDown = hightEndNumericUpDown;

            ManagerPresenter managerPresenter = new ManagerPresenter(this);
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
