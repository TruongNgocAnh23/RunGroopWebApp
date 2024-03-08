using RunGroopWebApp.Models;

namespace RunGroopWebApp.Interfaces
{
    public interface IArtilesImageRepository
    {
        Task<IEnumerable<ArtilesImage>> GetAll();
        Task<ArtilesImage> GetById(int id);
        Task<ArtilesImage> GetByIdNoTracking(int id);
        bool Add(ArtilesImage artiles);
        bool Update(ArtilesImage artiles);
        bool Delete(ArtilesImage artiles);
        bool Save();
    }
}
