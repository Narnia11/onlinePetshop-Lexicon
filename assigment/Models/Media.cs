using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class Media
    {
        [Key]
        public int Media_id { get; set; }
        public string Media_Name { get; set; }
        public string Media_description { get; set; }
        public string Media_path { get; set; }
        public int? Media_Category_id { get; set; }
        public int? Media_Item_id { get; set; }
        public string Media_User_id { get; set; }
        public byte Media_Type { get; set; }

        public Category Category { get; set; }
        public Item Item { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }

    }
}
