using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.UnitOfWorks;

namespace LMSystem.Services
{
    public class IssueBookService : IIssueBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IssueBookService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Create(IssueBookViewModel issueBookViewModel)
        {
            IssueBookEntity issueBookEntity = new IssueBookEntity()

            {
                id = Guid.NewGuid().ToString(),
                Bookid = issueBookViewModel.Bookid,
                Memberid = issueBookViewModel.Memberid,
                IssueDate = issueBookViewModel.IssueDate,
                DueDate = issueBookViewModel.DueDate,
                Status = "Issued",
            };
            _unitOfWork.IssueBookRepository.Create(issueBookEntity);
            _unitOfWork.Commit();

        }

        public bool Delete(string id)
        {
            try
            {
                IssueBookEntity issueBookEntity = _unitOfWork.IssueBookRepository.Getby(w => w.id == id).SingleOrDefault();
                if (issueBookEntity != null)
                {
                    issueBookEntity.IsInActive = true;
                    _unitOfWork.IssueBookRepository.Update(issueBookEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<IssueBookViewModel> GetAll()
        {
            IEnumerable<IssueBookViewModel> IssueBook = (from i in _unitOfWork.IssueBookRepository.GetAll()
                                                         join m in _unitOfWork.MemberRepository.GetAll()
                                                         on i.Memberid equals m.id
                                                         join b in _unitOfWork.BookRepository.GetAll()
                                                         on i.Bookid equals b.id

                                                         where !i.IsInActive && !m.IsInActive && !b.IsInActive
                                                         select new IssueBookViewModel
                                                         {
                                                             id = i.id,
                                                             Bookid = i.Bookid,
                                                             Memberid = i.Memberid,
                                                             IssueDate = i.IssueDate,
                                                             DueDate = i.DueDate,
                                                             BookInfo = b.Title,
                                                             MemberInfo = m.Name,



                                                         }).AsEnumerable();
            return IssueBook;
        }

        public IssueBookViewModel GetById(string id)
        {
            return _unitOfWork.IssueBookRepository.Getby(w => w.id == id && !w.IsInActive).Select(s => new IssueBookViewModel
            {
                id = s.id,
                Bookid = s.Bookid,
                Memberid = s.Memberid,
                IssueDate = s.IssueDate,
                DueDate = s.DueDate,
            }).FirstOrDefault();
        }

        public void Update(IssueBookViewModel issueBookViewModel)
        {
            IssueBookEntity issueBookEntity = new IssueBookEntity()

            {
                id = issueBookViewModel.id,
                Bookid = issueBookViewModel.Bookid,
                Memberid = issueBookViewModel.Memberid,
                IssueDate = issueBookViewModel.IssueDate,
                DueDate = issueBookViewModel.DueDate,
                Status = "Issued",
            };
            _unitOfWork.IssueBookRepository.Update(issueBookEntity);
            _unitOfWork.Commit();
        }
        public decimal Return(string id)
        {
            decimal result = 0;
            try
            {
                IssueBookEntity issueBookEntity = _unitOfWork.IssueBookRepository.Getby(w => w.id == id).SingleOrDefault();
                if (issueBookEntity != null)
                {
                    BookEntity bookEntity = _unitOfWork.BookRepository.Getby(w => w.id == issueBookEntity.Bookid).SingleOrDefault();
                    if (issueBookEntity.DueDate < DateTime.Now)
                    {
                        issueBookEntity.Issuefees = bookEntity.UnitPrice * 0.15m;


                    }
                    else
                    {
                        issueBookEntity.Issuefees = bookEntity.UnitPrice * 0.05m;


                    }
                    issueBookEntity.ReturnDate = DateTime.Now;
                    issueBookEntity.Status = "Return";
                    issueBookEntity.IsInActive = true;
                    _unitOfWork.IssueBookRepository.Update(issueBookEntity);
                    _unitOfWork.Commit();
                    result = issueBookEntity.Issuefees;
                }
            }
            catch (Exception)
            {

                return result;
            }
            return result;
        }

        public IEnumerable<IssueBookViewModel> GetIssueBooks()
        {
            var issueBooks = _unitOfWork.IssueBookRepository.GetIssueBooks();
            return issueBooks;
        }
    }
}
