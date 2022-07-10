using Database;

namespace MusicalInstrumentsDataBase.Models.Tables
{
    public class TmpMaterialInTransistSupply : DbRow
    {
        [Primary]
        public int TransistID { get; set; }
        [Primary]
        public int MaterialID { get; set; }
        public Decimal MaterialCount { get; set; }
    }
}
