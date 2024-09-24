using LMSystem.Models.ViewModels;
using LMSystem.Services;
using Microsoft.AspNetCore.Mvc;


namespace LMSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly IBookService _bookService;

        public BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IPublisherService publisherService)
        {
            this._bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _publisherService = publisherService;
        }
        public IActionResult Entry()
        {
            BindCategoryData();
            BindAuthorData();
            BindPublisherData();
            return View();
        }

        private void BindPublisherData()
        {
            IEnumerable<PublisherViewModel> Publisher = _publisherService.GetPublishers();
            ViewBag.Publisher = Publisher;
        }

        private void BindAuthorData()
        {
            IEnumerable<AuthorViewModel> Author = _authorService.GetAuthors();
            ViewBag.Author = Author;

        }

        private void BindCategoryData()
        {
            IEnumerable<CategoryViewModel> Category = _categoryService.GetCategories();
            ViewBag.Category = Category;

        }

        [HttpPost]
        public IActionResult Entry(BookViewModel bookViewModel)
        {
            try
            {
                _bookService.Create(bookViewModel);
                ViewData["Info"] = "Successfully save to the system";
                ViewData["status"] = true;
            }
            catch (Exception e)
            {

                ViewData["Info"] = "Errp save to the system" + e.Message;
                ViewData["status"] = false;
            }
            BindCategoryData();
            BindAuthorData();
            BindPublisherData();
            return View();
        }


        public IActionResult List()
        {
            var book = _bookService.GetAll().Result;
            return View(book);
        }
        public IActionResult Edit(string id)
        {
            var bookView = _bookService.GetById(id);
            BindCategoryData();
            BindAuthorData();
            BindPublisherData();
            return View(bookView);
        }
        [HttpPost]
        public IActionResult Update(BookViewModel bookViewModel)
        {
            try
            {
                _bookService.Update(bookViewModel);

                TempData["Info"] = "Successfully update to the system";
                TempData["status"] = true;
            }
            catch (Exception e)
            {

                TempData["Info"] = "Errp update to the system" + e.Message;
                TempData["status"] = false;
            }


            return RedirectToAction("list");
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                // Attempt to delete the book by ID using the service
                _bookService.Delete(id);

                // Prepare TempData for feedback
                TempData["info"] = "Successfully deleted the record.";
                TempData["status"] = true;

                // Return JSON response for success
                return Json(new { success = true, message = "Record deleted successfully." });
            }
            catch (Exception e)
            {
                // Log the error (optional: depends on your logging approach)
                TempData["info"] = "An error occurred while deleting the record: " + e.Message;
                TempData["status"] = false;

                // Return JSON response for failure
                return Json(new { success = false, message = "Error: " + e.Message });
            }
        }

    }
}
