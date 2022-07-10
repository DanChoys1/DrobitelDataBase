using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace MusicalInstrumentsDataBase.Models.Tables
{
    public class Stock : DbRow
    {
        [Primary]
        [AutoIncrement]
        public int Id { get; set; }
        [Name]
        public string Addres { get; set; }
        public string Phone { get; set; }
    }
}
