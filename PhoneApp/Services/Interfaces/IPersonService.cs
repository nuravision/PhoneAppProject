using PhoneApp.Helpers.Enums;
using PhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.Services.Interfaces
{
    public interface IPersonService
    {
        void Create(Person person);
        List<Person> GetAll();
        Person GetById(int id);
        void Delete(Person person);
        void Edit(int id,Person person);
        List<Person> Sort(SortType sort);
    }
}
