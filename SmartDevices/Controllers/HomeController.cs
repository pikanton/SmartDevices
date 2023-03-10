using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDevices.Models.Interfaces;
using SmartDevices.Models.ViewModels;

namespace SmartDevices.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Info()
        {
            return View();
        }

    }
}
