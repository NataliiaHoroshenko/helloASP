using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace helloASP.Models
{
    public class SelfDefenseItemViewModel
    {
        public int Id {get;set;}
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Тип")]
        public string Type { get; set; }
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }
        [Display(Name = "Опис")]
        public string Description { get; set; }
        [Display(Name = "Фото")]
        public string Image { get; set; }
    }
    public class SelfDefenseCreateViewModel
    {
        [Display(Name = "Назва")]
        [Required(ErrorMessage = "This field is required")]
        public virtual string Name { get; set; }
        [Display(Name = "Тип")]
        [Required(ErrorMessage = "This field is required")]
        public virtual string Type { get; set; }
        [Display(Name = "Ціна")]
        [Required(ErrorMessage = "This field is required")]
        public virtual decimal Price { get; set; }
        [Display(Name = "Опис")]
        public virtual string Description { get; set; }
        [Display(Name = "Фото")]
        public virtual HttpPostedFileBase Image { get; set; }
    }
    public class SelfDefenseEditViewModel
    {
        public virtual int Id { get; set; }
        [Display(Name = "Назва")]
        [Required(ErrorMessage = "This field is required")]
        public virtual string Name { get; set; }
        [Display(Name = "Тип")]
        [Required(ErrorMessage = "This field is required")]
        public virtual string Type { get; set; }
        [Display(Name = "Ціна")]
        [Required(ErrorMessage = "This field is required")]
        public virtual decimal Price { get; set; }
        [Display(Name = "Опис")]
        public virtual string Description { get; set; }
        //[Display(Name = "Фото")]
        //public virtual HttpPostedFileBase Image { get; set; }
    }
}