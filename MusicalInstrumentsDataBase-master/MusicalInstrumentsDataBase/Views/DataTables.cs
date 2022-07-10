using Presenters;

namespace Views
{
    public partial class DataTables : Form, IManager
    {
        public DataGridView DataGridView 
        { 
            get { return dataGridView; }
        }

        public event EventHandler DeleteEvent;
        public event EventHandler EditEvent;
        public event EventHandler AddEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler SaveDataToDbEvent;
        public event EventHandler DbChangedEvent;
        public event EventHandler ViewClosingEvent;

        public DataTables()
        {
            InitializeComponent();

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tablesComboBox.Items.Insert((int)IManager.ChoiseDb.MaterialInStock, "Материалы на складе");
            tablesComboBox.Items.Insert((int)IManager.ChoiseDb.Material, "Материалы");
            tablesComboBox.Items.Insert((int)IManager.ChoiseDb.Stock, "Склад");
            tablesComboBox.Items.Insert((int)IManager.ChoiseDb.Route, "Маршрут");
            tablesComboBox.Items.Insert((int)IManager.ChoiseDb.TransferOrder, "Заказ перемещения");
            tablesComboBox.Items.Insert((int)IManager.ChoiseDb.Supply, "Поставка");
            tablesComboBox.Items.Insert((int)IManager.ChoiseDb.SupplyMaterial, "Материал поставки");
            tablesComboBox.Items.Insert((int)IManager.ChoiseDb.TmpMaterialInTransistSupply, "Материал транзитного склада");

            ManagerPresenter ManagerPresenter = new ManagerPresenter(this);

            tablesComboBox.SelectedIndex = 0;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выделите строку.", "Сообщение");
                return;
            }

            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Сообщение", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                DeleteEvent.Invoke(sender, e);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1)
            {
                MessageBox.Show("Выделите строку.", "Сообщение");
                return;
            }

            EditEvent.Invoke(sender, e);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddEvent.Invoke(sender, e);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateEvent.Invoke(sender, e);
        }

        private void saveToDbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataToDbEvent.Invoke(sender, e);
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        private void tablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            DbChangedEvent.Invoke(sender, e);
        }

        void IManager.FillColumnsHeader(IManager.ChoiseDb choisenDb)
        {
            this.Text = tablesComboBox.Text;

            switch (choisenDb)
            {
            case IManager.ChoiseDb.MaterialInStock:

                dataGridView.ColumnCount = 3;
                dataGridView.Columns[0].HeaderText = "ID Склада";
                dataGridView.Columns[1].HeaderText = "ID Материала";
                dataGridView.Columns[2].HeaderText = "Кол-во";
                break;

            case IManager.ChoiseDb.Material:

                dataGridView.ColumnCount = 2;
                dataGridView.Columns[0].HeaderText = "ID Материала";
                dataGridView.Columns[1].HeaderText = "Название";
                break;

            case IManager.ChoiseDb.Stock:

                dataGridView.ColumnCount = 3;
                dataGridView.Columns[0].HeaderText = "ID Склада";
                dataGridView.Columns[1].HeaderText = "Адрес";
                dataGridView.Columns[2].HeaderText = "Телефон";
                break;

            case IManager.ChoiseDb.Route:

                dataGridView.ColumnCount = 5;
                dataGridView.Columns[0].HeaderText = "ID маршрута";
                dataGridView.Columns[1].HeaderText = "ID транзитного склада";
                dataGridView.Columns[2].HeaderText = "ID склада получателя";
                dataGridView.Columns[3].HeaderText = "ID склада отправителя";
                dataGridView.Columns[4].HeaderText = "Время доставки";
                break;

            case IManager.ChoiseDb.TransferOrder:

                dataGridView.ColumnCount = 4;
                dataGridView.Columns[0].HeaderText = "ID заказа";
                dataGridView.Columns[1].HeaderText = "ID маршрута";
                dataGridView.Columns[2].HeaderText = "Статус";
                dataGridView.Columns[3].HeaderText = "Дата";
                break;

            case IManager.ChoiseDb.Supply:

                dataGridView.ColumnCount = 5;
                dataGridView.Columns[0].HeaderText = "ID поставки";
                dataGridView.Columns[1].HeaderText = "ID заказа";
                dataGridView.Columns[2].HeaderText = "Статус";
                dataGridView.Columns[3].HeaderText = "Дата отгрузки";
                dataGridView.Columns[4].HeaderText = "Дата поступления";
                break;

            case IManager.ChoiseDb.SupplyMaterial:

                dataGridView.ColumnCount = 3;
                dataGridView.Columns[0].HeaderText = "ID поставки";
                dataGridView.Columns[1].HeaderText = "ID материала";
                dataGridView.Columns[2].HeaderText = "Кол-во";
                break;

            case IManager.ChoiseDb.TmpMaterialInTransistSupply:

                dataGridView.ColumnCount = 3;
                dataGridView.Columns[0].HeaderText = "ID транзитного склада";
                dataGridView.Columns[1].HeaderText = "ID материала";
                dataGridView.Columns[2].HeaderText = "Кол-во";
                break;
            }
        }

        private void Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewClosingEvent.Invoke(sender, e);
        }
    }
}
