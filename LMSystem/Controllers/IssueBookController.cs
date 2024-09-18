using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Controllers
{
    public class IssueBookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly IIssueBookService _issueBookService;

        public IssueBookController(IBookService bookService, IMemberService memberService, IIssueBookService issueBookService)
        {
            this._bookService = bookService;
            this._memberService = memberService;
            this._issueBookService = issueBookService;
        }
        public IActionResult Entry()
        {
            BindBookdata();
            BindMemberdata();
            return View();
        }

        private void BindMemberdata()
        {
            IEnumerable<MemberViewModel> Member = _memberService.GetMembers();
            ViewBag.Member = Member;
        }

        private void BindBookdata()
        {
            var issuedBookIds = _issueBookService.GetIssueBooks()
                                     .Where(i => i.Status.Equals("Issued"))
                                     .Select(i => i.Bookid);

            IEnumerable<BookViewModel> book = _bookService.GetBooks()
                                                          .Where(b => !issuedBookIds.Contains(b.id))
                                                          .Select(b => new BookViewModel
                                                          {
                                                              id = b.id,
                                                              Title = b.Title
                                                          }).ToList();

            
            ViewBag.Book = book;
        }
        [HttpPost]
        public IActionResult Entry(IssueBookViewModel issueBookViewModel)
        {
            try
            {
                _issueBookService.Create(issueBookViewModel);
                ViewData["Info"] = "Successfully save to the system";
                ViewData["status"] = true;
            }
            catch (Exception e)
            {

                ViewData["Info"] = "Errp save to the system" + e.Message;
                ViewData["status"] = false;
            }
            BindBookdata();
            BindMemberdata();
            return View();

        }
        [HttpPost]
        public IActionResult Update(IssueBookViewModel issueBookViewModel)
        {
            try
            {
                _issueBookService.Update(issueBookViewModel);
                TempData["Info"] = "Successfully update to the system";
                TempData["status"] = true;
            }
            catch (Exception e)
            {

                TempData["Info"] = "Error update to the system" + e.Message;
                TempData["status"] = false;
            }

            return RedirectToAction("list");

        }
        public IActionResult List()
        {
            var issueBook = _issueBookService.GetAll().ToList();
            return View(issueBook);
        }
        public IActionResult Edit(string id)
        {
            var issueBookView = _issueBookService.GetById(id);
            BindBookdata();
            BindMemberdata();
            return View(issueBookView);
        }
        public IActionResult Delete(string id)
        {
            try
            {
                _issueBookService.Delete(id);

                TempData["info"] = "Successfully delete to the system";
                TempData["status"] = true;


            }
            catch (Exception e)
            {

                TempData["info"] = "Error occrur when deleting to the system" + e.Message;
                TempData["status"] = false;
            }
            return RedirectToAction("list");
        }
        public IActionResult Return(string id)
        {
            try
            {
              decimal result=  _issueBookService.Return(id);
                if(result != 0)
                {
                    TempData["info"] = $"Book return Successfully and your issue amount is {result}";
                    TempData["status"] = true;

                }
                else
                {

                    TempData["info"] = "Error occur when book returning to the system";
                    TempData["status"] = false;

                }


            }
            catch (Exception e)
            {

                TempData["info"] = "Error occrur when book returning to the system" + e.Message;
                TempData["status"] = false;
            }
            return RedirectToAction("list");
        }  }
}


        
    

