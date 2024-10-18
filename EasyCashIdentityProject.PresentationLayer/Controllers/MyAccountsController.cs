using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDtos appUserEditDtos = new AppUserEditDtos();
            appUserEditDtos.Name = values.Name;
            appUserEditDtos.Surname = values.Surname;
            appUserEditDtos.PhoneNumber = values.PhoneNumber;
            appUserEditDtos.Email = values.Email;
            appUserEditDtos.City = values.City;
            appUserEditDtos.District = values.Disctrict;
            appUserEditDtos.ImageUrl = values.ImageUrl;
            return View(appUserEditDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDtos appUserEditDtos)
        {
            if (appUserEditDtos.Password == appUserEditDtos.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = appUserEditDtos.PhoneNumber;
                user.Surname = appUserEditDtos.Surname;
                user.City = appUserEditDtos.City;
                user.Disctrict = appUserEditDtos.District;
                user.Name = appUserEditDtos.Name;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDtos.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();

        }
    }
}
