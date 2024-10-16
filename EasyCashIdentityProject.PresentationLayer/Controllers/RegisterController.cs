﻿using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code = random.Next(100000, 1000000);

                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.EmailAdrress,
                    City = "Antalya",
                    Disctrict = "Kepez",
                    ImageUrl = "cccc",
                    ConfirmCode = code

                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "onurcankarateke2@gmail.com");
                    MailboxAddress mailboxAdressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAdressTo);

                    var bodybuilder = new BodyBuilder();
                    bodybuilder.TextBody = "Your code for registration: " + code;
                    mimeMessage.Body = bodybuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Confirmation Code"; 

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("onurcankarateke2@gmail.com", "");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDto.EmailAdrress;

                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();
        }
    }
}
