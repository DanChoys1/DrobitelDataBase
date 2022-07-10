using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalInstrumentsDataBase.Models.Tables
{
    internal class MaterialInStock : DbRow
    {
        [Primary]
        public int StockId { get; set; }

        [Primary]
        public int MaterialId { get; set; }

        public int Count { get; set; }
    }
}
