using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public class BookRepository : BaseRepository<BookEntity>, IBookRepository
    {
        private readonly LMSystemDbContext _dbContext;

        public BookRepository(LMSystemDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<BookViewModel> GetBooks()
        {
            return _dbContext.Books.Where(w => !w.IsInActive).Select(s => new BookViewModel
            {
                id = s.id,
                Title = s.Title,

            }).ToList();
        }
    }
}
