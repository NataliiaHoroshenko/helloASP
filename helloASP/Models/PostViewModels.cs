using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace helloASP.Models
{

    public class PostCreateViewModel
    {
        [Display(Name="Назва поста")]
        [Required(ErrorMessage ="Pole name Obovyzrovo")]
        public string Name { get; set; }

        [Display(Name = "Url-посилання")]
        [Required(ErrorMessage = "Pole URL Obovyzrovo")]
        public string UrlSlug { get; set; }

        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Оберіть категорію")]
        public int CategoryId { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
    public class PostItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Пост")]
        public string Name { get; set; }

        [Display(Name = "Категорія")]
        public string CategoryName { get; set; }

        [Display(Name = "Url-посилання")]
        public string UrlSlug { get; set; }
    }
    public class PostEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Назва категорії")]
        public string Name { get; set; }

        [Display(Name = "Url-посилання")]
        public string UrlSlug { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Оберіть категорію")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}