using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public interface IIssueBookRepository:IBaseRepository<IssueBookEntity>
    {
        IEnumerable<IssueBookViewModel> GetIssueBooks();
    }
}
