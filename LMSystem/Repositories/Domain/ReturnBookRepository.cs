using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public class ReturnBookRepository:BaseRepository<IssueBookEntity>,IReturnBookRepository
    {
        private readonly LMSystemDbContext _dbContext;

        public ReturnBookRepository(LMSystemDbContext dbContext):base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
