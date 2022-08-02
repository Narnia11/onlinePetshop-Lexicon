using Microsoft.AspNetCore.Http;
using Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ViewModels
{
  public  class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims =new List<string>();
            Roles =new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }

        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Phone number is not valid!")]
        [Display(Name = "phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(10, ErrorMessage = "Personal number should have 10 characters!")]
        [Display(Name = "personal number")]
        public string NationalCode { get; set; }

    }
}
