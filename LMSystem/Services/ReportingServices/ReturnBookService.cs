using LMSystem.Models.ViewModels;
using LMSystem.UnitOfWorks;
using System.Net;

namespace LMSystem.Services.ReportingServices
{
    public class ReturnBookService : IReturnBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReturnBookService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IList<ReturnBookViewModel> ReturnBook(string FromDate,string ToDate, string Bookid)
        {
            if (Bookid is not null && Bookid!="Select Book")
            {
                var ReturnBook = (from i in _unitOfWork.IssueBookRepository.GetAll()
                                  join m in _unitOfWork.MemberRepository.GetAll()
                                  on i.Memberid equals m.id
                                  join b in _unitOfWork.BookRepository.GetAll()
                                  on i.Bookid equals b.id

                                  where i.IsInActive=true
                                  && i.Bookid == Bookid && DateTime.Parse(FromDate) <= i.ReturnDate
                                       && DateTime.Parse(ToDate) >= i.ReturnDate
                                  select new ReturnBookViewModel
                                  {
                                      IssueDate = i.IssueDate.ToString("yyyy-MM-dd"),
                                      DueDate = i.DueDate.ToString("yyyy-MM-dd"),
                                      BookInfo = b.Title,
                                      MemberInfo = m.Name,
                                      ReturnDate = i.ReturnDate.ToString("yyyy-MM-dd"),
                                      Status = i.Status,
                                      Issuefees = i.Issuefees,


                                  }).ToList();
                return ReturnBook;

            }
            else
            {
                var ReturnBook = (from i in _unitOfWork.IssueBookRepository.GetAll()
                                   join m in _unitOfWork.MemberRepository.GetAll()
                                   on i.Memberid equals m.id
                                   join b in _unitOfWork.BookRepository.GetAll()
                                   on i.Bookid equals b.id
                                  where i.IsInActive = true
                                     &&  DateTime.Parse(FromDate) <=i.ReturnDate //2024-8-1<=2024-08-31 00:42:02.1574553 
                                     && DateTime.Parse(ToDate) >= i.ReturnDate//2024-08-31>=2024-08-31 
                                  select new ReturnBookViewModel
                                  {
                                       IssueDate = i.IssueDate.ToString("yyyy-MM-dd"),
                                       DueDate = i.DueDate.ToString("yyyy-MM-dd"),
                                       BookInfo = b.Title,
                                       MemberInfo = m.Name,
                                       ReturnDate = i.ReturnDate.ToString("yyyy-MM-dd"),
                                       Status = i.Status,
                                       Issuefees = i.Issuefees,


                                   }).ToList();
                return ReturnBook;


            }
        }
    }
}
