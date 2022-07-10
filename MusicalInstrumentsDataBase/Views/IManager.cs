using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Views
{
    internal interface IManager
    {
        event EventHandler UpdateEvent;

        DataGridView DataGridView { get; }

        void ShowView();
    }
}
