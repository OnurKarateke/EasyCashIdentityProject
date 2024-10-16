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
    }
}
