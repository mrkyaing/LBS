using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public class IssueBookRepository : BaseRepository<IssueBookEntity>, IIssueBookRepository
    {
        private readonly LMSystemDbContext _dbContext;

        public IssueBookRepository(LMSystemDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<IssueBookViewModel> GetIssueBooks()
        {
            return _dbContext.IssueBooks.Where(w => !w.IsInActive).Select(s => new IssueBookViewModel
            {
                id = s.id,
                IssueDate = s.IssueDate,
                DueDate = s.DueDate,
                Bookid = s.Bookid,
                Status = s.Status,

            }).ToList();
        }
    }
}
