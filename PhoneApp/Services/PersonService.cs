using PhoneApp.Data;
using PhoneApp.Helpers.Enums;
using PhoneApp.Models;
using PhoneApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.Services
{
    public class PersonService : IPersonService
    {
        private static int id = 1;
 
        public void Create(Person person)
        {
            person.Id = id; 
            AppDbContext.People.Add(person);
            id++;
        }
        public List<Person> GetAll()
        {
            return AppDbContext.People.ToList();
        }

        public Person GetById(int id)
        {
            return AppDbContext.People.FirstOrDefault(p => p.Id == id);
        }
        public void Delete(Person person)
        {
            AppDbContext.People.Remove(person);
        }

        public void Edit(int id,Person person)
        {
           Person existPerson= AppDbContext.People.FirstOrDefault(m=>m.Id == id);
            if (!string.IsNullOrWhiteSpace(person.Name))
            {
                existPerson.Name = person.Name;
            }
            if (!string.IsNullOrWhiteSpace(person.Surname))
            {
                existPerson.Surname = person.Surname;
            }
            if (!string.IsNullOrWhiteSpace(person.Phone))
            {
                existPerson.Phone = person.Phone;
            }
        }

        public List<Person> Sort(SortType sort)
        {
            switch (sort) { 
                case SortType.Asc:
                    return AppDbContext.People.OrderBy(m=>m.Name).ToList(); 
                case SortType.Desc:
                    return AppDbContext.People.OrderByDescending(m => m.Name).ToList();
            }
            return null;
        }
    }
}
