using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ASP.NETMVCProject.Data;
using ASP.NETMVCProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASP.NETMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const int PageSize = 5;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            var products = _context.Products
                                   .Include(p => p.Category)
                                   .OrderBy(p => p.ProductId)
                                   .Skip((page - 1) * PageSize)
                                   .Take(PageSize)
                                   .Select(p => new
                                   {
                                       p.ProductId,
                                       p.ProductName,
                                       p.CategoryId,
                                       CategoryName = p.Category.CategoryName
                                   })
                                   .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = Math.Ceiling((double)_context.Products.Count() / PageSize);

            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["success"] = "Product Created successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            TempData["success"] = "Product Updated successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            TempData["success"] = "Product Deleted successfully";

            return RedirectToAction("Index");
        }
    }
}

