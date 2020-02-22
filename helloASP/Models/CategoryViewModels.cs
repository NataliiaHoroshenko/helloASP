using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace helloASP.Models
{

    public class CategoryCreateViewModel
    {
        [Display(Name="Назва категорії")]
        [Required(ErrorMessage ="Pole name Obovyzrovo")]
        public virtual string Name { get; set; }

        [Display(Name = "Url-посилання")]
        [Required(ErrorMessage = "Pole URL Obovyzrovo")]
        public virtual string UrlSlug { get; set; }

        [Display(Name = "Опис")]
        public virtual string Description { get; set; }
    }
    public class CategoryItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Назва категорії")]
        public virtual string Name { get; set; }

        [Display(Name = "Url-посилання")]
        public virtual string UrlSlug { get; set; }
    }
}