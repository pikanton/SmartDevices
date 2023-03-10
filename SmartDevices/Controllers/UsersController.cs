using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartDevices.Models;
using SmartDevices.Models.Interfaces;
using SmartDevices.Models.ViewModels;
using System.Security.Claims;

namespace SmartDevices.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAllUsers _allUsers;
        public UsersController(IAllUsers allUsers)
        {
            _allUsers = allUsers;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            User? currUser = _allUsers.GetUserByIdentity(user);
            if (currUser != null)
            {
                await Authenticate(currUser.Id.ToString()); // аутентификация
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("ErrorLogin");
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            User? currUser = _allUsers.GetUserByIdentity(user);
            if (currUser == null)
            {
                _allUsers.AddUser(user);
                await Authenticate(user.Id.ToString()); // аутентификация
                return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("ErrorRegister");
        }
        private async Task Authenticate(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userId)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Users");
        }
        public IActionResult ErrorLogin()
        {
            return View();
        }
        public IActionResult ErrorRegister()
        {
            return View();
        }
    }
}
