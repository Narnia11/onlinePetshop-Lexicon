using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class CreateCategoryViewModel
    {


        public string Category_name { get; set; }

        public string Category_description { get; set; }

        public IFormFile Category_PrimaryPhoto { get; set; }
        public DateTime? CreationDateTime { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

    }
}
