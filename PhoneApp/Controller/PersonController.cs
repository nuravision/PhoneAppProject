using PhoneApp.Exceptions;
using PhoneApp.Helpers.Enums;
using PhoneApp.Models;
using PhoneApp.Services;
using PhoneApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.Controller
{
    public class PersonController
    {
        private readonly IPersonService _personService;
        public PersonController()
        {
            _personService = new PersonService();
        }
        public void Create()
        {
            Console.Write("Add name:");
            string name = Console.ReadLine();

            Console.Write("Add surname:");
            string surname = Console.ReadLine();


            Console.Write("Add phone:");
            string phone = Console.ReadLine();

            Person person = new()
            {
                Name = name,
                Surname = surname,
                Phone = phone
            };
            _personService.Create(person);

        }

        public void GetAll()
        {
            var response = _personService.GetAll();
            foreach (var item in response)
            {
                string res = $"Id:{item.Id} - Name:{item.Name} - Surname: {item.Surname} - Phone:{item.Phone}";
                Console.WriteLine(res);
            }
        }

        public void Delete()
        {
            Id: Console.Write("Add contact id: ");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);
            try
            {
                if (isCorrectId)
                {
                    var person = _personService.GetById(id);
                    if (person is null)
                    {
                        throw new NotFoundException("Data not found");
                    }
                    _personService.Delete(person);
                    Console.WriteLine("Data deleted!");

                }
                else
                {
                    Console.WriteLine("Id format is wrong,please select again: ");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Id;
            }
        }


        public void Edit()
        {
        Id: Console.Write("Add contact id: ");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);
            try
            {
                if (isCorrectId)
                {

                    var person = _personService.GetById(id);
                    if (person is null)
                    {
                        throw new NotFoundException("Data not found");
                    }
                    Console.Write("Add name:");
                    string name=Console.ReadLine();
                    Console.Write("Add surname:");
                    string surname = Console.ReadLine();
                    Console.Write("Add phone:");
                    string phone = Console.ReadLine();

                    _personService.Edit(id, new Person { Name = name, Surname = surname, Phone = phone });
                }
                else
                {
                    Console.WriteLine("Id format is wrong,please select again: ");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Id;
            }
        }

        public void Sorting()
        {
            Sorting: Console.WriteLine("1-ASC  2-DESC");
            Console.WriteLine("Select sort type:");
            string sortStr = Console.ReadLine();
            int sortType;
            bool isCorrectSortType = int.TryParse(sortStr, out sortType);
            if (isCorrectSortType)
            {
                if (sortType==(int)SortType.Asc || sortType==(int)SortType.Desc)
                {
                    List<Person> response = new();

                    if (sortType==(int)SortType.Asc)
                    {
                        response=_personService.Sort(SortType.Asc);
                    }
                    else
                    {
                        response = _personService.Sort(SortType.Desc);
                    }
                    foreach (var item in response) {
                        string res = $"Id:{item.Id} - Name:{item.Name} - Surname: {item.Surname} - Phone:{item.Phone}";
                        Console.WriteLine(res);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sort type format is wrong,please select again: ");
                goto Sorting;
            }
        }
    }
}
