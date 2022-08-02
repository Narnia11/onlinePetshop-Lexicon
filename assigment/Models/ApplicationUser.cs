using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Address { get; set; }
        public byte Marital_status { get; set; }   
        public string City { get; set; }
        public ICollection<Media> Medias { get; set; }


    }
}
