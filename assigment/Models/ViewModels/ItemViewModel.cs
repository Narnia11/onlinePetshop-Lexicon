using Model;
using Model.Model;
using System;
using System.Collections.Generic;

namespace assignment.Models
{
    public class ItemViewModel
    {

        public int Item_id { get; set; }
        public string Item_Name { get; set; }
        public int Item_price { get; set; }
        public string Item_description { get; set; }
        public int Item_Category_id { get; set; }
        public Category Category { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public string Item_ImagePath { get; set; }

      

    }
}
