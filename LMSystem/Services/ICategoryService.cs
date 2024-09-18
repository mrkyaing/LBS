using LMSystem.Models.ViewModels;

namespace LMSystem.Services
{
    public interface ICategoryService
    {
        void Create(CategoryViewModel categoryViewModel);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel GetById(string id);
        void Update(CategoryViewModel categoryViewModel);
        bool Delete(string id);
        IEnumerable<CategoryViewModel> GetCategories();
    }
}
