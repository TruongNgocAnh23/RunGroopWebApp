using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.Repository;
using RunGroopWebApp.ViewModels;
using System.Diagnostics;

namespace RunGroopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IArtilesRepository _artilesRepository;

        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository, IArtilesRepository artilesRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _artilesRepository = artilesRepository;
        }
        public async Task<IActionResult> Index(string categoryId)
        {
            var category = await _categoryRepository.GetAll();
            ViewBag.Category = category;
            var img = await _artilesRepository.GetAllImage();
            ViewBag.Img = img;
            var artiles = await _artilesRepository.GetAll("");
            ViewBag.Artiles = artiles;
            return View();
        }
        [HttpGet("/Home/Category/{categoryId}")]
        public async Task<IActionResult> Category(string categoryId)
        {
            var category = await _categoryRepository.GetAll();
            ViewBag.Category = category;
            var img = await _artilesRepository.GetAllImage();
            ViewBag.Img = img;
            var artiles = await _artilesRepository.GetAll(categoryId);
            ViewBag.Artiles = artiles;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
