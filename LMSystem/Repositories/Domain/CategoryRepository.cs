using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Repositories.Domain
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        private readonly LMSystemDbContext _dbContext;

        public CategoryRepository(LMSystemDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _dbContext.Categories.Where(w => !w.IsInActive).Select(s => new CategoryViewModel
            {
                id = s.id,
                Name = s.Name,
            }).ToList();
        }
    }
}
