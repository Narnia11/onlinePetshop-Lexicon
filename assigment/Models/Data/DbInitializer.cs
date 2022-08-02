using assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assigment.Models
{
   internal   class DbInitializer
    {
        internal static void Initialize(ExDBContext context)
        {
            context.Database.Migrate();
        }
    }
}
