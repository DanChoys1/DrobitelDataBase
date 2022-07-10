using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace MusicalInstrumentsDataBase.Presenters
{
    internal interface IDbPresenter
    {
        void Connect();
        void Disconnect();

        void SetSourseTables(params DbRow[][] soursRows);

        bool IsSaved();
    }
}
