using LMSystem.Repositories.Domain;

namespace LMSystem.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        IMemberRepository MemberRepository { get; }
        IBookRepository BookRepository { get; }
        IIssueBookRepository IssueBookRepository { get; }
        IOverDueBookRepository OverdueBookRepository { get; }
        IReturnBookRepository ReturnBookRepository { get; }
        void Commit();
        void RoolBack();

    }
}
