using LMSystem.Models.ViewModels;

namespace LMSystem.Services
{
    public interface IAuthorService
    {
        void Create(AuthorViewModel authorViewModel);
        IEnumerable<AuthorViewModel> GetAll();
        AuthorViewModel GetById(string id);
        void Update(AuthorViewModel authorViewModel);
        bool Delete(string id);
        IEnumerable<AuthorViewModel> GetAuthors();
    }
}
