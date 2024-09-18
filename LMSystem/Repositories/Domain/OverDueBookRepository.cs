using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public class OverDueBookRepository : BaseRepository<IssueBookEntity>, IOverDueBookRepository
    {
        private readonly LMSystemDbContext _dbContext;

        public OverDueBookRepository(LMSystemDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
