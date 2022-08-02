using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Model
{
    public class  Category
    {
        [Key]
        public int Category_id { get; set; }
        [Display(Name = "نام دسته بندی")]
        public string Category_name { get; set; }
        [Display(Name = "توضیحات دسته بندی")]
        public string Category_description { get; set; }
        [Display(Name = "نوع دسته بندی")]
        public byte Category_Type { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<Media> Medias { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreationDateTime { get; set; }
        [Display(Name = "تاریخ آخرین بروزرسانی")]
        public DateTime LastUpdateDateTime { get; set; }

    }
}
