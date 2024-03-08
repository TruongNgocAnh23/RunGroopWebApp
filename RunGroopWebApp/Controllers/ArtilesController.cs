using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.Repository;
using RunGroopWebApp.ViewModels;
using System.Net.WebSockets;
using static System.Net.Mime.MediaTypeNames;

namespace RunGroopWebApp.Controllers
{
    public class ArtilesController : Controller
    {
        private readonly IArtilesRepository _artilesRepository;
        private readonly IPhotoService _photoService;
        private readonly IArtilesImageRepository _artilesImageRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ArtilesController(IArtilesRepository artilesRepository, IPhotoService photoService, IArtilesImageRepository artilesImageRepository, ICategoryRepository categoryRepository)
        {
            _artilesRepository = artilesRepository;
            _photoService = photoService;
            _artilesImageRepository = artilesImageRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryRepository.GetAll();
            ViewBag.Category = category;
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var category = await _categoryRepository.GetAll();
            ViewBag.ListCategory = new SelectList(category, "Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateArtilesViewModel artilesVM)
        {
            if (ModelState.IsValid)
            {
                var checkCategory = await _categoryRepository.GetById((int)artilesVM.CategoryId);
                var thumb = await _photoService.AddPhotoAsync(artilesVM.Images.First());
                var artiles = new Artiles
                {
                    Title = artilesVM.Title,
                    Content = artilesVM.Content,
                    CategoryId = checkCategory.Id,
                    Thumbnail = thumb.Url.ToString()
                };
                _artilesRepository.Add(artiles);

                foreach (var item in artilesVM.Images)
                {
                    var result = await _photoService.AddPhotoAsync(item);
                    var img = new ArtilesImage
                    {
                        Image = result.Url.ToString(),
                        ArtilesId = artiles.Id
                    };
                    _artilesImageRepository.Add(img);
                }
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(artilesVM);
        }
    }
}
