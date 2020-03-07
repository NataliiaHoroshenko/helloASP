using helloASP.Entites;
using helloASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace helloASP.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PostController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Post
        public ActionResult Index()
        {
            var model = _context.Posts.Select(p=>new PostItemViewModel {
                Id=p.Id,
                Name=p.Name,
                CategoryName=p.Category.Name,
                UrlSlug=p.UrlSlug
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            PostCreateViewModel model = new PostCreateViewModel();
            model.Categories = GetCategorySelect();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(PostCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.Name = model.Name;
                post.UrlSlug = model.UrlSlug;
                post.Description = model.Description;
                post.CategoryId = model.CategoryId;
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            model.Categories = GetCategorySelect();
            return View(model);
        }
        private List<SelectListItem> GetCategorySelect()
        {
            return _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cat = _context.Posts
                .Select(c => new PostEditViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    CategoryId=c.CategoryId,
                    Description=c.Description,
                    UrlSlug = c.UrlSlug
                })
                .SingleOrDefault(x => x.Id == id);
            if (cat == null)
                return RedirectToAction("Index");
            cat.Categories = GetCategorySelect();
            return View(cat);
        }

        public ActionResult Edit(PostEditViewModel model)
        {
            var cat = _context.Posts
                .SingleOrDefault(x => x.Id == model.Id);
            if (cat != null)
            {
                cat.Name = model.Name;
                cat.UrlSlug = model.UrlSlug;
                cat.CategoryId = model.CategoryId;
                cat.Description = model.Description;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}