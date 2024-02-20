using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryRepository.GetAll();
            return View(category);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var category = await _categoryRepository.GetById(id);
            return View(category);
        }
        //[HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) 
            {
                return View(category);
            }
            _categoryRepository.Add(category);
            return RedirectToAction("Index");
        }
    }
}
