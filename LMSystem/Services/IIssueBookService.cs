using LMSystem.Models.ViewModels;

namespace LMSystem.Services
{
    public interface IIssueBookService
    {
        void Create(IssueBookViewModel issueBookViewModel);
        IEnumerable<IssueBookViewModel> GetAll();
        IssueBookViewModel GetById(string id);
        void Update(IssueBookViewModel issueBookViewModel);
        bool Delete(string id);
        decimal Return(string id);
        IEnumerable<IssueBookViewModel>GetIssueBooks();
    }
}
