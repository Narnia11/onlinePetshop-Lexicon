using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assigment.Services
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindByNameAsync(this UserManager<ApplicationUser> um, string name)
        {
            return await um?.Users?.SingleOrDefaultAsync(x => x.UserName == name);
        }

        public static async Task<ApplicationUser> FindByPhoneNumberAsync(this UserManager<ApplicationUser> um, string phoneNumber)
        {
            return await um?.Users?.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

    }
}
