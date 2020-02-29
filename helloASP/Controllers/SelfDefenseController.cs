using helloASP.Entites;
using helloASP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace helloASP.Controllers
{
    public class SelfDefenseController : Controller
    {
        private readonly ApplicationDbContext _context;
        // GET: SelfDefense
        public SelfDefenseController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            List<SelfDefenseItemViewModel> models = _context.SelfDefenses.Select(x =>
                new SelfDefenseItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Price = x.Price,
                    Description = x.Description,
                    Image = x.Image
                }).ToList();
            return View(models);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SelfDefenseCreateViewModel model)
        {
            string fileName = Path.GetRandomFileName()+".jpg";
            string serverPath = Server.MapPath("~/Upload");
            string folderSave = Path.Combine(serverPath, fileName);
            if (ModelState.IsValid)
            {
                SelfDefense item = new SelfDefense();
                item.Name = model.Name;
                item.Type = model.Type;
                item.Price = model.Price;
                item.Description = model.Description;
                item.Image = fileName;
                _context.SelfDefenses.Add(item);
                _context.SaveChanges();
                model.Image.SaveAs(folderSave);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sf = _context.SelfDefenses.Select(x =>
                new SelfDefenseEditViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Price = x.Price,
                    Description = x.Description,
                   // Image = x.Image
                }).SingleOrDefault(c => c.Id == id);
            if (sf == null)
                return RedirectToAction("Index");
            return View(sf);
        }
        [HttpPost]
        public ActionResult Edit(SelfDefenseEditViewModel model)
        {
            var item = _context.SelfDefenses
                .SingleOrDefault(x => x.Id == model.Id);
            if (item != null)
            {
                item.Name = model.Name;
                item.Price = model.Price;
                item.Type = model.Type;
                item.Description = model.Description;
                //item.Image = model.Image;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var sf = _context.SelfDefenses.Select(x =>
                new SelfDefenseItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Price = x.Price,
                    Description = x.Description,
                  //  Image = x.Image
                }).SingleOrDefault(c => c.Id == id);
            if (sf == null)
                return RedirectToAction("Index");
            return View(sf);
        }
        [HttpPost]
        public ActionResult Delete(SelfDefenseItemViewModel model)
        {
            var sf = _context.SelfDefenses
                .SingleOrDefault(x => x.Id == model.Id);
            if (sf != null)
            {
                _context.SelfDefenses.Remove(sf);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}