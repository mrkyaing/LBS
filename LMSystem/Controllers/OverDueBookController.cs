using LMSystem.Models.ViewModels;
using LMSystem.Services;
using LMSystem.Services.ReportingServices;
using LMSystem.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace LMSystem.Controllers
{
    public class OverDueBookController : Controller
    {
        private readonly IOverDueBookService _overDueBookService;
        private readonly IIssueBookService _issueBookService;
        private readonly IBookService _bookService;

        public OverDueBookController(IOverDueBookService overDueBookService, IIssueBookService issueBookService, IBookService bookService)
        {
            this._overDueBookService = overDueBookService;
            this._issueBookService = issueBookService;
            this._bookService = bookService;
        }
        public IActionResult OverDueBook()
        {
            BindIssueBookData();
            BindBookData();
            return View();
        }
        [HttpPost]
        public IActionResult OverDueBook(string FromDate,string ToDate,string Bookid)
        {IList<OverDueBookViewModel>overDueBook=_overDueBookService.OverDueBooks(FromDate, ToDate, Bookid);
            string fileName = $"OverDueBookReport{DateTime.Now.ToString()}.xlsx";
            if (overDueBook.Any())
            {
                var fileContentsInBytes = ReportHelper.ExportToExcel(overDueBook, fileName);
                var contentType = "application/vnd.openxmlformat-officedocument.spreadsheet.sheet";
                ViewData["Info"] = "Successfully download the overdue ExcelFile.";
                ViewData["Status"] = true;
                return File(fileContentsInBytes, contentType, fileName);
            }
            else
            {

                BindIssueBookData();
                BindBookData();
                ViewData["Info"] = "Not OverDue";
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
          IEnumerable<IssueBookViewModel>issueBook=_issueBookService.GetIssueBooks();
            ViewBag.IssueBook = issueBook;
        }
    }
}
