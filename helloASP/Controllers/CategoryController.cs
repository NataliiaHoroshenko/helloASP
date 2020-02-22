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
        private readonly ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
               // GET: Category
        public ActionResult Index()
        {
            List<CategoryItemViewModel> list = _context.Categories.Select(x => new CategoryItemViewModel
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
                Category category = new Category();
                category.Name = model.Name;
                category.UrlSlug = model.UrlSlug;
                category.Description = model.Description;
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cat = _context.Categories
                .Select(c => new CategoryItemViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    UrlSlug = c.UrlSlug
                })
                .SingleOrDefault(x => x.Id == id);
            if (cat == null)
                return RedirectToAction("Index");
            return View(cat);
        }
        [HttpPost]
        public ActionResult Delete(CategoryItemViewModel model)
        {
            var cat = _context.Categories
                .SingleOrDefault(x => x.Id == model.Id);
            if (cat != null)
            {
                _context.Categories.Remove(cat);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}