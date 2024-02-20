using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IClubRepository _clubRepository;
        public ClubController(ApplicationDbContext context,IClubRepository clubRepository)
        {
            _context = context;
            _clubRepository = clubRepository;
        }
        public async Task<IActionResult> Index()
        {
            var clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetById(id);
            return View(club);

        }
        public async Task<IActionResult> Create(Club club)
        {
            if (ModelState.IsValid) 
            {
                return View(club);
            }
            _clubRepository.Add(club);
            return RedirectToAction("Index");
        }
    }
}
