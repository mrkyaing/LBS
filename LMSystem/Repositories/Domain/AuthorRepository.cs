using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
    {
        private readonly LMSystemDbContext _dbContext;

        public AuthorRepository(LMSystemDbContext dbContext):base (dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AuthorViewModel> GetAuthors()
        {
            return _dbContext.Authors.Where(w => !w.IsInActive).Select(s => new AuthorViewModel
            {
                id = s.id,
                Name = s.Name,
            }).ToList();
        }
    }
}
