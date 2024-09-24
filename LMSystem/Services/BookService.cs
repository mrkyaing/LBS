using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.UnitOfWorks;


namespace LMSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(BookViewModel bookViewModel)
        {
            BookEntity bookEntity = new BookEntity()
            {
                id = Guid.NewGuid().ToString(),
                Title = bookViewModel.Title,
                Categoryid = bookViewModel.Categoryid,
                Authorid = bookViewModel.Authorid,
                Publisherid = bookViewModel.Publisherid,
                PublicationYear = bookViewModel.PublicationYear,
                NumberOfCopies = bookViewModel.NumberOfCopies,
                language = bookViewModel.language,
                Description = bookViewModel.Description,
                Version = bookViewModel.Version,
                ISBN = bookViewModel.ISBN,
                UnitPrice = bookViewModel.UnitPrice,
                CreatedAt = DateTime.Now,
            };
            _unitOfWork.BookRepository.Create(bookEntity);
            _unitOfWork.Commit();
        }

        public bool Delete(string id)
        {
            try
            {
                BookEntity bookEntity = _unitOfWork.BookRepository.Getby(w => w.id == id).SingleOrDefault();
                {
                    if (bookEntity != null)
                    {
                        bookEntity.IsInActive = true;
                        _unitOfWork.BookRepository.Update(bookEntity);
                        _unitOfWork.Commit();

                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            var books = from b in _unitOfWork.BookRepository.GetAll()
                        join c in _unitOfWork.CategoryRepository.GetAll()
                        on b.Categoryid equals c.id
                        join a in _unitOfWork.AuthorRepository.GetAll()
                        on b.Authorid equals a.id
                        join p in _unitOfWork.PublisherRepository.GetAll()
                        on b.Publisherid equals p.id
                        where !b.IsInActive
                        select new BookViewModel
                        {
                            id = b.id,
                            Title = b.Title,
                            Categoryid = b.Categoryid,
                            Authorid = b.Authorid,
                            Publisherid = b.Publisherid,
                            PublicationYear = b.PublicationYear,
                            NumberOfCopies = b.NumberOfCopies,
                            language = b.language,
                            Description = b.Description,
                            Version = b.Version,
                            ISBN = b.ISBN,
                            UnitPrice = b.UnitPrice,
                            CategoryInfo = c.Name,
                            AuthorInfo = a.Name,
                            PublisherInfo = p.Name,
                        };

            // Asynchronous query execution to prevent blocking
            return await Task.FromResult(books.AsEnumerable());
        }


        public IEnumerable<BookViewModel> GetBooks()
        {
            return _unitOfWork.BookRepository.GetBooks();
        }

        public BookViewModel GetById(string id)
        {
            return _unitOfWork.BookRepository.Getby(w => w.id == id && !w.IsInActive).Select(s => new BookViewModel
            {
                id = s.id,
                Title = s.Title,
                Categoryid = s.Categoryid,
                Authorid = s.Authorid,
                Publisherid = s.Publisherid,
                PublicationYear = s.PublicationYear,
                NumberOfCopies = s.NumberOfCopies,
                language = s.language,
                Description = s.Description,
                Version = s.Version,
                ISBN = s.ISBN,
                UnitPrice = s.UnitPrice,


            }).FirstOrDefault();
        }

        public void Update(BookViewModel bookViewModel)
        {
            BookEntity bookEntity = new BookEntity()
            {
                id = bookViewModel.id,
                Title = bookViewModel.Title,
                Categoryid = bookViewModel.Categoryid,
                Authorid = bookViewModel.Authorid,
                Publisherid = bookViewModel.Publisherid,
                PublicationYear = bookViewModel.PublicationYear,
                NumberOfCopies = bookViewModel.NumberOfCopies,
                language = bookViewModel.language,
                Description = bookViewModel.Description,
                Version = bookViewModel.Version,
                ISBN = bookViewModel.ISBN,
                UnitPrice = bookViewModel.UnitPrice,
                CreatedAt = DateTime.Now,
            };
            _unitOfWork.BookRepository.Update(bookEntity);
            _unitOfWork.Commit();
        }
    }

}



