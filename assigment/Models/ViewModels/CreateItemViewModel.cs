using Microsoft.AspNetCore.Http;
using Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class CreateItemViewModel
    {
        public string Item_Name { get; set; }
        public int Item_price { get; set; }
        public string Item_description { get; set; }
        public int Item_Category_id { get; set; }
        public IFormFile Item_PrimaryPhoto { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }
        public ICollection<Media> Medias { get; set; }

    }
}
