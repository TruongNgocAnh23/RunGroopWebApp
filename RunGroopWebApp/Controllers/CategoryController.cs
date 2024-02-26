using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;

namespace RunGroopWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPhotoService _photoService;

        public CategoryController(ICategoryRepository categoryRepository, IPhotoService photoService)
        {
            _categoryRepository = categoryRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> Create(CreateCategoryViewModel categoryVM)
        {
            if (ModelState.IsValid) 
            {
                var result = await _photoService.AddPhotoAsync(categoryVM.Image);
                var category = new Category
                {
                    Name = categoryVM.Name,
                    Image = result.Url.ToString()
                };
                _categoryRepository.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }    
            return View(categoryVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) return View("Error");
            var categoryVM = new EditCategoryViewModel
            {
                Name = category.Name,
                Id = category.Id
            };
            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCategoryViewModel categoryVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit category");
            }    
            var userCategory = await _categoryRepository.GetByIdNoTracking(id);
            if (userCategory != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userCategory.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(categoryVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(categoryVM.Image);
                var category = new Category
                {
                    Id = id,
                    Name = categoryVM.Name,
                    Image = photoResult.Url.ToString()
                };
                _categoryRepository.Update(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryVM);
            }    

        }
    }
}
