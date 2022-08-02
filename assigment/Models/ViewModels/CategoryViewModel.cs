using Model;
using Model.Model;
using System;
using System.Collections.Generic;

namespace assignment.Models
{
    public class CategoryViewModel
    {
        public int Category_id { get; set; }
        public string Category_name { get; set; }
        public string Category_description { get; set; }
        public byte Category_Type { get; set; }

        public string Category_ImagePath { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Media> Medias { get; set; }

      

    }
}
