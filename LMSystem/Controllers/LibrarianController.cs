using LMSystem.DAO;
using LMSystem.Models.Entities;
using LMSystem.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LMSystem.Controllers
{
    public class LibrarianController : Controller
    {
        private readonly LMSystemDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public LibrarianController(LMSystemDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            this._userManager = userManager;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EntryAsync(LibrarianViewModel librarianViewModel)
        {
            try
            {
                var user = new IdentityUser { UserName = librarianViewModel.Email, Email = librarianViewModel.Email };
                var result = await _userManager.CreateAsync(user, "CloudHRMS@prodev@123");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Librarian");
                    //Data Exchange from view Model to Entity
                    //ViewModels to Data Models
                    LibrarianEntity librarianEntity = new LibrarianEntity()
                    {
                        id = Guid.NewGuid().ToString(),
                        Name = librarianViewModel.Name,
                        Email = librarianViewModel.Email,
                        CreatedAt = DateTime.Now,
                        Userid = user.Id
                    };
                    _dbContext.Librarians.Add(librarianEntity);
                    _dbContext.SaveChanges();
                    ViewData["Info"] = "Successfully save to the system";
                    ViewData["status"] = true;
                }
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
            IList<LibrarianViewModel> librarian = _dbContext.Librarians.Where(w => !w.IsInActive).Select(s=>new LibrarianViewModel
            {
            id=s.id,
            Name = s.Name,
            Email = s.Email,
            }).ToList();
            if (!User.IsInRole("Librarian"))
            {
                var loginedUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                librarian = librarian.Where(u => u.Userid == loginedUser.Id).ToList();
            }
            return View(librarian);//passing the position view models to the views

        }
        public IActionResult Edit(string id)
        {
            LibrarianViewModel librarianView =_dbContext.Librarians.Where(w=>w.id==id && !w.IsInActive).Select(s=>new LibrarianViewModel
            {
                id = s.id,
                Name = s.Name,
                Email = s.Email,
                CreatedAt =s.CreatedAt,
                UpdatedAt=s.UpdatedAt

        }).FirstOrDefault();
            return View(librarianView);
        }
        [HttpPost]
        public IActionResult Update(LibrarianViewModel librarianViewModel)
        {
            try
            {
                LibrarianEntity librarianEntity = new LibrarianEntity()
                {
                    id = librarianViewModel.id,
                    Name = librarianViewModel.Name,
                    Email = librarianViewModel.Email,

                    CreatedAt= librarianViewModel.CreatedAt,
                    UpdatedAt = DateTime.Now,
                };
                _dbContext.Librarians.Update(librarianEntity);
                _dbContext.SaveChanges();
                ViewData["Info"] = "Successfully save to the system";
                ViewData["status"] = true;
            }
            catch (Exception e)
            {

                ViewData["Info"] = "Errp save to the system" + e.Message;
                ViewData["status"] = false;
            }
            return RedirectToAction("list");
        }
        public IActionResult Delete(string id)
        {
            try
            {
                LibrarianEntity librarianEntity = _dbContext.Librarians.Find(id);
                {
                    if (librarianEntity != null)
                    {
                        librarianEntity.IsInActive = true;
                        _dbContext.Librarians.Update(librarianEntity);
                        _dbContext.SaveChanges();
                        TempData["info"] = "Successfully delete to the system";
                    }
                }
            }
            catch (Exception e)
            {

                TempData["info"] = "Error occrur when deleting to the system"+e.Message;
            }
            return RedirectToAction("list");
        }
    }
}
