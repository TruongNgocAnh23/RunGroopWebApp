using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;

namespace RunGroopWebApp.Interfaces
{
    public interface IArtilesRepository
    {
        Task<IEnumerable<Artiles>> GetAll(string categoryId);
        Task<IEnumerable<Artiles>> GetAllSearch(SearchViewModel viewModel);
        Task<Artiles> GetById(int id);
        Task<Artiles> GetByIdNoTracking(int id);
        bool Add(Artiles artiles);
        bool Update(Artiles artiles);
        bool Delete(Artiles artiles);
        bool Save();
        Task<IEnumerable<ArtilesImage>> GetAllImage();
    }
}
