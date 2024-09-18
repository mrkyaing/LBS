using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LMSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(CategoryViewModel categoryViewModel)
        {
            try
               
            {
                _categoryService.Create(categoryViewModel);
                ViewData["Info"] = "Successfully save to the system";
                ViewData["status"] = true;
            }
            catch (Exception e)
            {

                ViewData["Info"] = "Errp save to the system"+e.Message;
                ViewData["status"] = false;
            }
             return View();
        }
        public IActionResult List()
        {
           var Category=_categoryService.GetAll();
            return View(Category);
        }
        public IActionResult Edit(string id) 
        {var categoryView=_categoryService.GetById(id);
            return View(categoryView);
        }
        [HttpPost]
        public IActionResult Update(CategoryViewModel categoryViewModel)
        {
            try
            {
                _categoryService.Update(categoryViewModel);
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
        public IActionResult Delete(string id)
        {
            try
            {
                  _categoryService.Delete(id);
                TempData["info"] = "Successfully delete to the system";
                TempData["status"] = true;

            }
            catch (Exception e)
            {

                TempData["info"] = "Error occrur when deleting to the system"+e.Message;
                TempData["status"] = false;
            }
            return RedirectToAction("list");
        }
    }
}
