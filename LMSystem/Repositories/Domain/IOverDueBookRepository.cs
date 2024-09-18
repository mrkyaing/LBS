using LMSystem.Models.Entities;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public interface IOverDueBookRepository:IBaseRepository<IssueBookEntity>
    {
    }
}
