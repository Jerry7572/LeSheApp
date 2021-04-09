using SQLite;

namespace prjLayoutDemo.Models
{
    public class CCustomer
    {
        [PrimaryKey, AutoIncrement]
        public int fId { get; set; }
        public string fName { get; set; }
        public string fPhone { get; set; }
        public string fEmail { get; set; }
        public string fAddrsss { get; set; }

    }
}
