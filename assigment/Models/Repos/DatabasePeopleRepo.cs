using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private ExDBContext _DBContext;
        public DatabasePeopleRepo(ExDBContext myDBContext)
        {
            _DBContext = myDBContext;
        }

        public Person CreatePerson(Person person)
        {
            Person p = new Person()
            {

                PersonName = person.PersonName,
                PersonPhoneNumber = person.PersonPhoneNumber,
                City = person.City,
            };
            _DBContext.People.Add(p);
            _DBContext.SaveChanges();
            return person;
        }

        public bool DeletePerson(Person person)
        {


            var result = _DBContext.People.FirstOrDefault(x => x.Id == person.Id);
            if (result != null)
            {
                _DBContext.People.Remove(result);
                _DBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Person FindPerson(int id)
        {
            return _DBContext.People.Include(x => x.City).Include(i => i.PersonLanguages).FirstOrDefault(x => x.Id == id);

        }

        public List<Person> GetPeoples()
        {
            return _DBContext.People.Include(x => x.City).Include(i => i.PersonLanguages).ToList();

        }

        public Person SearchPerson(string search)
        {
            return _DBContext.People.FirstOrDefault(x => x.City.Name.ToLower().Contains(search.ToLower()) || x.PersonName.Contains(search.ToLower()));

        }
        public void UpdatePerson(Person person)
        {
            _DBContext.People.Update(person);
            _DBContext.SaveChanges();
        }
    }
}
