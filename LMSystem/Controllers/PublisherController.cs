using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LMSystem.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
           _publisherService = publisherService;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(PublisherViewModel publisherViewModel)
        {
            try
            {
              
                _publisherService.Create(publisherViewModel);
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
           var publisher=_publisherService.GetAll();
            return View(publisher);
        }
        public IActionResult Edit(string id) 
        {
           var publisherView= _publisherService.GetById(id);
            return View(publisherView);
        }
        [HttpPost]
        public IActionResult Update(PublisherViewModel publisherViewModel)
        {
            try
            {
               _publisherService.Update(publisherViewModel);
                TempData["Info"] = "Successfully save to the system";
                TempData["status"] = true;
            }
            catch (Exception e)
            {

                TempData["Info"] = "Errp update to the system" + e.Message;
                TempData["status"] = false;
            }
            return RedirectToAction("list");
        }
        public IActionResult Delete(string id)
        {
            try
            {     _publisherService.Delete(id);
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
