using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace MusicalInstrumentsDataBase.Models.Tables
{
    public class TransferOrder : DbRow
    {
        [Primary]
        [AutoIncrement]
        public int OrderID { get; set; }
        public int RouteID { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
}
