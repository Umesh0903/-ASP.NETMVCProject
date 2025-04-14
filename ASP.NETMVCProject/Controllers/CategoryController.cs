using ASP.NETMVCProject.Models;
using ASP.NETMVCProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETMVCProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Category category)
        {
                _categoryService.Create(category);
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
                _categoryService.Update(category);
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            TempData["success"] = "Category and related products deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
