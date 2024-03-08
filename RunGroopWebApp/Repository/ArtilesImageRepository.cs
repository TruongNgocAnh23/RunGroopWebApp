using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Repository
{
    public class ArtilesImageRepository : IArtilesImageRepository
    {
        private readonly ApplicationDbContext _context;
        public ArtilesImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(ArtilesImage artiles)
        {
            _context.Add(artiles);
            return Save();
        }

        public bool Delete(ArtilesImage artiles)
        {
            _context.Remove(artiles);
            return Save();
        }

        public Task<IEnumerable<ArtilesImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ArtilesImage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArtilesImage> GetByIdNoTracking(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(ArtilesImage artiles)
        {
            _context.Update(artiles);
            return Save();
        }
    }
}
