using Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Item
    {
        [Key]
        public int Item_id { get; set; }
        public string Item_Name { get; set; }
        public int Item_price { get; set; }
        public string Item_description { get; set; }
        public int Item_Category_id { get; set; }
        public Category Category { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public ICollection<Media> Medias { get; set; }

    }
}
