using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Views
{
    internal interface IManager
    {
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler AddEvent;
        event EventHandler UpdateEvent;
        event EventHandler SaveDataToDbEvent;
        event EventHandler DbChangedEvent;
        event EventHandler ViewClosingEvent;

        DataGridView DataGridView { get; }

        enum ChoiseDb
        {
            MaterialInStock,
            Material,
            Stock,
            Route,
            TransferOrder,
            Supply,
            SupplyMaterial,
            TmpMaterialInTransistSupply
        }

        void ShowView();

        void FillColumnsHeader(ChoiseDb choisenDb);
    }
}
