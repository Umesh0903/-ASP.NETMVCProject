using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ASP.NETMVCProject.Data;
using ASP.NETMVCProject.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETMVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Categories.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        
        public IActionResult Create(Category category)
        {
            
                _context.Categories.Add(category);
                _context.SaveChanges();

            TempData["success"] = "Category Created successfully";
            return RedirectToAction("Index");
            

        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["success"] = "Category Updated successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}



