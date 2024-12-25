using PhoneApp.Models;

namespace PhoneApp.Data
{
    public class AppDbContext
    {
        public static List<Person> People;
        static AppDbContext()
        {
            People = new List<Person>();
        }
    }
}
