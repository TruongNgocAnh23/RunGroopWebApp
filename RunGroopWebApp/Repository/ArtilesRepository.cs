using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;

namespace RunGroopWebApp.Repository
{
    public class ArtilesRepository : IArtilesRepository
    {
        private readonly ApplicationDbContext _context;

        public ArtilesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Artiles artiles)
        {
            _context.Add(artiles);
            return Save();
        }

        public bool Delete(Artiles artiles)
        {
            _context.Remove(artiles);
            return Save();
        }

        public async Task<IEnumerable<Artiles>> GetAll(string categoryId)
        {
             if (categoryId.Length > 0) 
               return await _context.Artiles.OrderByDescending(o=>o.Id).Where(p=>p.CategoryId == int.Parse(categoryId)).ToListAsync();
             else
               return await _context.Artiles.OrderByDescending(o => o.Id).ToListAsync();
        }
        public async Task<IEnumerable<Artiles>> GetAllSearch(SearchViewModel viewModel)
        {
            var searchTerm = viewModel.SearchTerm;

            if (viewModel.Results.Count() > 0)
                return await _context.Artiles.Where(p => p.CategoryId == searchTerm).ToListAsync();

            else
                return await _context.Artiles.ToListAsync();

        }

        public async Task<Artiles> GetById(int id)
        {
            return await _context.Artiles.FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<Artiles> GetByIdNoTracking(int id)
        {
            return await _context.Artiles.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Artiles artiles)
        {
            _context.Update(artiles);
            return Save();
        }
        public async Task<IEnumerable<ArtilesImage>> GetAllImage()
        {
            return await _context.ArtilesImage.ToListAsync();
        }
    }
}
