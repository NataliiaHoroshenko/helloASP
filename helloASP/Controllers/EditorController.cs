using helloASP.Entites;
using helloASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace helloASP.Controllers
{
    public class EditorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EditorController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Editor
        public ActionResult Index()
        {
                List<EditorViewModels> otchers = _context.Editors.Select(x => new EditorViewModels
                {
                    Id = x.Id,
                    Otcher = x.Otcher
                }).ToList();
                return View(otchers);
            
        }
        [ValidateInput(false)]
        public ActionResult Add(EditorViewModels model)
        {
            if (ModelState.IsValid)
            {
                Editor item = new Editor();
                item.Id = model.Id + 1;
                item.Otcher = model.Otcher;
                _context.Editors.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}