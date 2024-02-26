using RunGroopWebApp.Models;

namespace RunGroopWebApp.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> GetByIdNoTracking(int id);
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(Category category);
        bool Save();
    }
}
