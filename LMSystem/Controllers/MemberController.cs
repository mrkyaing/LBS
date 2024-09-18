using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using LMSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LMSystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(MemberViewModel memberViewModel)
        {
            try
            {
                _memberService.Create(memberViewModel);
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
            var Member=_memberService.GetAll();
            return View(Member);
        }
        public IActionResult Edit(string id) 
        {var memberView=_memberService.GetByid(id);
            return View(memberView);
        }

        [HttpPost]
        public IActionResult Update(MemberViewModel memberViewModel)
        {
            try 
            { _memberService.Update(memberViewModel);
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
            {            _memberService.Delete(id);
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
