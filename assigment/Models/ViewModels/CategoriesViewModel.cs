using Model;
using Model.Model;
using System;
using System.Collections.Generic;

namespace assignment.Models
{
    public class CategoriesViewModel
    {
        public int Category_id { get; set; }
        public string Category_name { get; set; }
        public string Category_description { get; set; }
        public byte Category_Type { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<Media> Medias { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }

        public string Category_ImagePath { get; set; }




    }
}
