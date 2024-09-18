using LMSystem.DAO;
using LMSystem.Repositories.Domain;

namespace LMSystem.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LMSystemDbContext _dbContext;

        public UnitOfWork(LMSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {

            get
            {
                return _categoryRepository ?? new CategoryRepository(_dbContext);
            }
        }
        private IAuthorRepository _authorRepository;
        public IAuthorRepository AuthorRepository
        {
            get
            {
                return _authorRepository ?? new AuthorRepository(_dbContext);
            }
        }
        private IPublisherRepository _publisherRepository;
        public IPublisherRepository PublisherRepository
        {
            get
            {
                return _publisherRepository ?? new PublisherRepository(_dbContext);
            }
        }
        private IMemberRepository _memberRepository;
        public IMemberRepository MemberRepository
        {
            get
            {
                return _memberRepository ?? new MemberRepository(_dbContext);
            }
        }
        private IBookRepository _bookRepository;
        public IBookRepository BookRepository
        {
            get
            {
                return _bookRepository ?? new BookRepository(_dbContext);
            }
        }
        private IssueBookRepository _issueBookRepository;
        public IIssueBookRepository IssueBookRepository
        {
            get
            {
                return _issueBookRepository ?? new IssueBookRepository(_dbContext);
            }
        }
        private IOverDueBookRepository _overDueBookRepository;
        public IOverDueBookRepository OverdueBookRepository
        {
            get
            {
                return _overDueBookRepository ?? new OverDueBookRepository(_dbContext);
            }
        }
        private IReturnBookRepository _returnBookRepository;
        public IReturnBookRepository ReturnBookRepository
        {
            get
            {
                return _returnBookRepository ?? new ReturnBookRepository(_dbContext);
            }
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void RoolBack()
        {
            _dbContext.Dispose();
        }
    }
}
