using Microsoft.EntityFrameworkCore;

namespace CountryDirectoryApp_CloudDb
{
    // Country - страна
    public class Country
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Alpha2Code { get; set; }
        // конструктор по умолчанию
        public Country() {}
    }
}
