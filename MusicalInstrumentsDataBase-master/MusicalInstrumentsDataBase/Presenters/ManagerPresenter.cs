using System;
using System.Collections.Generic;
using System.Text;
using Views;
using Database;
using MusicalInstrumentsDataBase.Models.Tables;
using MusicalInstrumentsDataBase.Presenters;

namespace Presenters
{
    internal class ManagerPresenter
    {
        private readonly IManager _manager;

        private readonly MySqlDatabase _database;

        private readonly DbRowList<MaterialInStock> _dbMaterialInStock;
        private readonly DbRowList<Stock> _dbStock;
        private readonly DbRowList<Material> _dbMaterial;
        private readonly DbRowList<Route> _dbRoute;
        private readonly DbRowList<TransferOrder> _dbTransferOrder;
        private readonly DbRowList<Supply> _dbSupply;
        private readonly DbRowList<SupplyMaterial> _dbSupplyMaterial;
        private readonly DbRowList<TmpMaterialInTransistSupply> _dbTmpMaterialInTransistSupply;

        private IManager.ChoiseDb _choisenDb;

        private readonly Dictionary<IManager.ChoiseDb, IDbPresenter> _dbPresenter;

        public ManagerPresenter(IManager view)
        {
            _manager = view;

            _choisenDb = IManager.ChoiseDb.MaterialInStock;

            _manager.DbChangedEvent += ChangeDb;
            _manager.ViewClosingEvent += Closing;
            
            _database = new MySqlDatabase("музыкальные инструменты", "127.0.0.1", "root", "azdaniil1");

            _dbMaterialInStock = new DbRowList<MaterialInStock>("материал на складе");
            _dbStock = new DbRowList<Stock>("склад");
            _dbMaterial = new DbRowList<Material>("материал");
            _dbRoute = new DbRowList<Route>("маршрут");
            _dbTransferOrder = new DbRowList<TransferOrder>("заказ перемещения");
            _dbSupply = new DbRowList<Supply>("поставка");
            _dbSupplyMaterial = new DbRowList<SupplyMaterial>("материал поставки");
            _dbTmpMaterialInTransistSupply = new DbRowList<TmpMaterialInTransistSupply>("материал на транзитном складе", "create_tmp_mat_in_tr_supp");

            _dbPresenter = new Dictionary<IManager.ChoiseDb, IDbPresenter>()
            {
                { IManager.ChoiseDb.MaterialInStock,             new DbPresenter<MaterialInStock>(_manager, new EmptiChangeInfo<MaterialInStock>(), _database, _dbMaterialInStock) },
                { IManager.ChoiseDb.Stock,                       new DbPresenter<Stock>(_manager, new StockChangeInformation(), _database, _dbStock) },
                { IManager.ChoiseDb.Material,                    new DbPresenter<Material>(_manager, new MaterialChangeInformation(), _database, _dbMaterial) },
                { IManager.ChoiseDb.Route,                       new DbPresenter<Route>(_manager, new EmptiChangeInfo<Route>(), _database, _dbRoute) } ,
                { IManager.ChoiseDb.TransferOrder,               new DbPresenter<TransferOrder>(_manager, new TransferOrderChangeInformation(), _database, _dbTransferOrder) },
                { IManager.ChoiseDb.Supply,                      new DbPresenter<Supply>(_manager, new SupplyChangeInformation(), _database, _dbSupply) },
                { IManager.ChoiseDb.SupplyMaterial,              new DbPresenter<SupplyMaterial>(_manager, new SupplyMaterialChangeInformation(), _database, _dbSupplyMaterial) },
                { IManager.ChoiseDb.TmpMaterialInTransistSupply, new DbPresenter<TmpMaterialInTransistSupply>(_manager, new EmptiChangeInfo<TmpMaterialInTransistSupply>(), _database, _dbTmpMaterialInTransistSupply) }
            };
        }
            
        private void ChangeDb(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (!_dbPresenter[_choisenDb].IsSaved())
            {
                DialogResult res = MessageBox.Show("Изменения не были сохранены. Продолжить?",
                                                        "Сообщение", MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                {
                    return;
                }
            }

            _dbPresenter[_choisenDb].Disconnect();

            _choisenDb = (IManager.ChoiseDb)comboBox.SelectedIndex;

            _manager.FillColumnsHeader(_choisenDb);

            switch (_choisenDb)
            {
            case IManager.ChoiseDb.MaterialInStock:


                break;

            case IManager.ChoiseDb.Material:


                break;

            case IManager.ChoiseDb.Stock:


                break;

            case IManager.ChoiseDb.Route:


                break;

            case IManager.ChoiseDb.TransferOrder:

                InitialiseRows();
                _dbPresenter[_choisenDb].SetSourseTables(_dbRoute.GetRows().ToArray());
                break;

            case IManager.ChoiseDb.Supply:

                InitialiseRows();
                _dbPresenter[_choisenDb].SetSourseTables(_dbTransferOrder.GetRows().ToArray());
                break;

            case IManager.ChoiseDb.SupplyMaterial:

                InitialiseRows();
                _dbPresenter[_choisenDb].SetSourseTables(_dbSupply.GetRows().ToArray(), _dbMaterial.GetRows().ToArray());
                break;

            case IManager.ChoiseDb.TmpMaterialInTransistSupply:


                break;
            }

            _dbPresenter[_choisenDb].Connect();
        }

        private void InitialiseRows()
        {
            _database.InitialRows(_dbMaterialInStock);
            _database.InitialRows(_dbStock);
            _database.InitialRows(_dbMaterial);
            _database.InitialRows(_dbRoute);
            _database.InitialRows(_dbTransferOrder);
            _database.InitialRows(_dbSupply);
            _database.InitialRows(_dbSupplyMaterial);
            _database.InitialRows(_dbTmpMaterialInTransistSupply);
        }

        private void Closing(object sender, EventArgs e)
        {
            if (!_dbPresenter[_choisenDb].IsSaved())
            {
                DialogResult res = MessageBox.Show("Изменения не были сохранены. Продолжить?",
                                                        "Сообщение", MessageBoxButtons.YesNo);

                if (res == DialogResult.No)
                {
                    FormClosingEventArgs closeEvent = (FormClosingEventArgs)e;
                    closeEvent.Cancel = true;
                }
            }
        }
    }
}
