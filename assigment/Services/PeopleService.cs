using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepo _PeopleRepo;
        public PeopleService(IPeopleRepo PeopleRepo)
        {
            this._PeopleRepo = PeopleRepo;
        }

        public void CreatePerson(Person person)
        {
            _PeopleRepo.CreatePerson(person);
        }

        public void DeletePerson(Person person)
        {
            _PeopleRepo.DeletePerson(person);

        }

        public Person FindPerson(int id)
        {
            return _PeopleRepo.FindPerson(id);
        }

        public List<Person> GetPeoples()
        {
            return _PeopleRepo.GetPeoples();
        }

        public Person SearchPerson(string search)
        {
            return _PeopleRepo.SearchPerson(search);
        }

        public void UpdatePerson(Person person)
        {
            _PeopleRepo.UpdatePerson(person);
        }
    }
}
