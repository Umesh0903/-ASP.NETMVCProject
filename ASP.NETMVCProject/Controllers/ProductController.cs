using ASP.NETMVCProject.Models;
using ASP.NETMVCProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NETMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private const int PageSize = 5;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int page = 1)
        {
            var result = _productService.GetPagedProducts(page, PageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = result.TotalPages;

            return View(result.Products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
           
                _productService.Create(product);
                TempData["success"] = "Product created successfully!";
                return RedirectToAction(nameof(Index));

            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
                _productService.Update(product);
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();

            _productService.Delete(id);
            TempData["success"] = "Product deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
