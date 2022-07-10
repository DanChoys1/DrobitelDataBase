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

        private readonly IDbPresenter _dbPresenter;

        public ManagerPresenter(IManager view)
        {
            _manager = view;

            _database = new MySqlDatabase("new_schema", "127.0.0.1", "root", "azdaniil1");

            _dbMaterialInStock = new DbRowList<MaterialInStock>("таблица", "new_procedure");
            _database.InitialRows(_dbMaterialInStock);

            _dbPresenter = new DbPresenter<MaterialInStock>(_manager, new EmptiChangeInfo<MaterialInStock>(), _database, _dbMaterialInStock);
            _dbPresenter.Connect();
        }
    }
}
