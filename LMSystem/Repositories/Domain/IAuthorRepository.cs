using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Repositories.Common;

namespace LMSystem.Repositories.Domain
{
    public interface IAuthorRepository : IBaseRepository<AuthorEntity>
    {
        IEnumerable<AuthorViewModel> GetAuthors();
    }
}
