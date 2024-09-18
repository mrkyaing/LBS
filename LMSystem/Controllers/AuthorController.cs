using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Services;
using LMSystem.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LMSystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(AuthorViewModel authorViewModel)
        {
            try
            {

                _authorService.Create(authorViewModel);
                ViewData["Info"] = "Successfully save to the system";
                ViewData["status"] = true;
            }
            catch (Exception e)
            {

                ViewData["Info"] = "Errp save to the system" + e.Message;
                ViewData["status"] = false;
            }
            return View();
        }
        public IActionResult List()
        {
            var Author = _authorService.GetAll();
            return View(Author);
        }
        public IActionResult Edit(string id)
        {
            var authorView = _authorService.GetById(id);
            return View(authorView);
        }
        [HttpPost]
        public IActionResult Update(AuthorViewModel authorViewModel)
        {
            try
            {
                _authorService.Update(authorViewModel);
                TempData["Info"] = "Successfully save to the system";
                TempData["status"] = true;
            }
            catch (Exception e)
            {

                TempData["Info"] = "Errp save to the system" + e.Message;
                TempData["status"] = false;
            }
            return RedirectToAction("list");
        }
        public IActionResult Delete(string id)
        {
            try
            {
                _authorService.Delete(id);
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
    }
}
