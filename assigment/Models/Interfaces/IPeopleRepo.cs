using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public interface IPeopleRepo
    {
        List<Person> GetPeoples();

        Person FindPerson(int id);
        Person SearchPerson(string search);

        Person CreatePerson(Person person);
        bool DeletePerson(Person person);

        void UpdatePerson(Person person);

    }
}
