using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public interface IPeopleService
    {
        List<Person> GetPeoples();

        Person FindPerson(int id);
        Person SearchPerson(string search);

        void CreatePerson(Person person);
        void DeletePerson(Person person);
        void UpdatePerson(Person person);
    }
}
