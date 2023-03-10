using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartDevices.Models;
using SmartDevices.Models.Interfaces;
using SmartDevices.Models.ViewModels;

namespace SmartDevices.Controllers
{
    [Authorize]
    public class HousesController : Controller
    {
        private readonly IAllHouses _allHouses;
        private readonly IAllDevices _allDevices;
        private readonly IAllRooms _allRooms;
        private readonly IAllUsers _allUsers;
        public HousesController(IAllDevices allDevices, IAllRooms allRooms, IAllHouses allHouses, IAllUsers allUsers)
        {
            _allDevices = allDevices;
            _allRooms = allRooms;
            _allHouses = allHouses;
            _allUsers = allUsers;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Дома";
            HousesListViewModel obj = new();
            obj.AllHouses = _allHouses.GetHouses(int.Parse(User.Identity.Name));
            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _allHouses.DeleteHouse(id);
            return RedirectToAction("List");
        }
        public ViewResult Add()
        {
            ViewBag.Title = "Добавление";
            HousesListViewModel obj = new();
            obj.AllHouses = _allHouses.GetHouses(int.Parse(User.Identity.Name));
            return View(obj);
        }
        [HttpPost]
        public ActionResult Add(House house)
        {
            house.User = _allUsers.GetObjectUser(int.Parse(User.Identity.Name));
            _allHouses.AddHouse(house);
            return RedirectToAction("Complete");
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            HousesListViewModel obj = new();
            obj.CurrentHouse = _allHouses.GetObjectHouse(id);
            obj.AllHouses = _allHouses.GetHouses(int.Parse(User.Identity.Name));
            return View(obj);
        }
        [HttpPost]
        public ActionResult EditHouse(House house)
        {
            _allHouses.EditHouse(house);
            return RedirectToAction("Complete");
        }
        public ViewResult Complete()
        {
            return View();
        }
    }
}
