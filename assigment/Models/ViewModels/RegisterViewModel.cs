using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ViewModels
{
   public class RegisterViewModel
    {
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone Number is not valid")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="repeat password")]
        [Compare("Password", ErrorMessage ="pass word is not the same")]
        public string ConfirmPassword { get; set; }
    }
}
