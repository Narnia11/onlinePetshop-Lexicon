using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Enums
{

    public enum MediaTypeEnum
    {
        [Description("عکس معرفی")]
        [Display(Name = "عکس معرفی")]
        IntroImage,
        [Description("عکس در وبلاگ")]
        [Display(Name = "عکس در وبلاگ")]
        SeceondryImage,
        [Description("عکس گالری")]
        [Display(Name = "عکس گالری")]
        GalleryImage,
        [Description("عکس هتل")]
        [Display(Name = "عکس هتل")]
        HotelImage,
        [Description("عکس دسته بندی")]
        [Display(Name = "عکس دسته بندی")]
        CategoryImage,
        [Description("عکس پروفایل")]
        [Display(Name = "عکس پروفایل")]
        ProfilePicture,
        [Description("عکس کارت ملی")]
        [Display(Name = "عکس کارت ملی")]
        NationalCardPhoto,
        [Description("عکس معرفی نام")]
        [Display(Name = "عکس معرفی نامه")]
        RecommendationPhoto,

    }

    public enum CategoryTypeEnum
    {
        [Description("کتگوری مقاله")]
        [Display(Name = "کتگوری مقاله")]
        ArticleCategory,
        [Description("کتگوری عکس")]
        [Display(Name = "کتگوری عکس")]
        MediaCategory,
        [Description("کتگوری هتل")]
        [Display(Name = "کتگوری هتل")]
        HotelCategory,

    }
    public enum IsActiveEnum
    {
        [Description("غیر فعال")]
        [Display(Name = "غیر فعال")]
        DeActive,
        [Description("فعال")]
        [Display(Name = "فعال")]
        Active


    }
    public enum Marital_status_Enum
    {
        [Description("مجرد")]
        [Display(Name = "مجرد")]
        Single,
        [Description("متاهل")]
        [Display(Name = "متاهل")]
        Married

    }
}
