using LMSystem.Models.ViewModels;
using LMSystem.Services;
using LMSystem.Services.ReportingServices;
using LMSystem.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace LMSystem.Controllers
{
    public class ReturnBookController : Controller
    { 
        private readonly IReturnBookService _returnBookService;
        private readonly IBookService _bookService;
        private readonly IIssueBookService _issueBookService;

        public ReturnBookController(IReturnBookService returnBookService,IBookService bookService,IIssueBookService issueBookService)
        {
            this._returnBookService = returnBookService;
            this._bookService = bookService;
            this._issueBookService = issueBookService;
        }
        public IActionResult ReturnBook()
        {
            BindIssueBookData();
            BindBookData();
            return View();
        }
        [HttpPost]
        public IActionResult ReturnBook(string FromDate,string ToDate, string Bookid)
        {

            IList<ReturnBookViewModel> ReturnBook = _returnBookService.ReturnBook(FromDate,ToDate, Bookid);
            string fileName = $"ReturnBookReport{DateTime.Now.ToString()}.xlsx";
            if (ReturnBook.Any())
            {
                decimal totalIssueFees = ReturnBook.Sum(rb => rb.Issuefees);
                ReturnBook.Add(new ReturnBookViewModel
                {
                    Status = "Total Issue Fees",
                    Issuefees = totalIssueFees
                });
                var fileContentsInBytes = ReportHelper.ExportToExcel(ReturnBook, fileName);
                var contentType = "application/vnd.openxmlformat-officedocument.spreadsheet.sheet";
                ViewData["Info"] = "Successfully download the overdue ExcelFile.";
                ViewData["Status"] = true;
                return File(fileContentsInBytes, contentType, fileName);
            }
            else
            {

                BindIssueBookData();
                BindBookData();
                ViewData["Info"] = "Not Return";
                ViewData["Status"] = false;
                return View();
            }
        }
        private void BindBookData()
        {
            IEnumerable<BookViewModel> book = _bookService.GetBooks();
            ViewBag.Book = book;
        }

        private void BindIssueBookData()
        {
            IEnumerable<IssueBookViewModel> issueBook = _issueBookService.GetIssueBooks();
            ViewBag.IssueBook = issueBook;
        }
    }
}
