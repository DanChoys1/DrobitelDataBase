using Database;

namespace MusicalInstrumentsDataBase.Models.Tables
{
    public class Material : DbRow
    {
        [Primary]
        [AutoIncrement]
        public int Id { get; set; }
        [Name]
        public string Name { get; set; }
    }
}
