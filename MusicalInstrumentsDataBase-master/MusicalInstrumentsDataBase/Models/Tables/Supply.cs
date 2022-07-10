using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace MusicalInstrumentsDataBase.Models.Tables
{
    public class Supply : DbRow
    {
        [Primary]
        [AutoIncrement]
        public int ID { get; set; }
        public int TransferOrderID { get; set; }
        public string Status { get; set; }
        public string outDate { get; set; }
        public string inDate { get; set; }
    }
}
