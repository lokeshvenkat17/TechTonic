using TechTonic.API.Models.Domain;

namespace TechTonic.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}