using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class CreatePersonViewModel
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonPhoneNumber { get; set; }
        public int CityId { get; set; }

    }
}
