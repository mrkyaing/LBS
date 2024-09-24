using LMSystem.Models.ViewModels;

namespace LMSystem.Services
{
    public interface IBookService
    {
        void Create(BookViewModel bookViewModel);
        Task<IEnumerable<BookViewModel>> GetAll();
        BookViewModel GetById(string id);
        void Update(BookViewModel bookViewModel);
        bool Delete(string id);
        IEnumerable<BookViewModel> GetBooks();

    }
}
