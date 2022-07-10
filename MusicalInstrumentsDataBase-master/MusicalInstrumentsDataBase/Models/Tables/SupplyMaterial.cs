using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace MusicalInstrumentsDataBase.Models.Tables
{
    public class SupplyMaterial : DbRow
    {
        [Primary]
        public int SupplyId { get; set; }

        [Primary]
        public int MaterialId { get; set; }

        public int Count { get; set; }
    }
}
