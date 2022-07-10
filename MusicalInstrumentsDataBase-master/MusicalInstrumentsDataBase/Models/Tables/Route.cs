using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace MusicalInstrumentsDataBase.Models.Tables
{
    internal class Route : DbRow
    {
        [Primary]
        [AutoIncrement]
        public int RouteId { get; set; }
        public int TransitWarehouseId { get; set; }
        public int inStockId { get; set; }
        public int outStockIs { get; set; }
        public string Time { get; set; }
    }
}
