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
        public string Name { get; set; }
        public int Coast { get; set; }
        public int Power { get; set; }
        public int MaxSize { get; set; }
        public int Performance { get; set; }
        public int Mass { get; set; }
        public int NumberEngines { get; set; }
        public string Side { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
