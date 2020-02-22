using helloASP.Entites;
using helloASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace helloASP.Controllers
{
    public class CategoryController : Controller
    {

               // GET: Category
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<CategoryItemViewModel> list = context.Categories.Select(x => new CategoryItemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UrlSlug = x.UrlSlug
            }).ToList();

            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //CategoryCreateViewModel model = new CategoryCreateViewModel();
            //model.Name = "Юмор";
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                Category category = new Category();
                category.Name = model.Name;
                category.UrlSlug = model.UrlSlug;
                category.Description = model.Description;
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}