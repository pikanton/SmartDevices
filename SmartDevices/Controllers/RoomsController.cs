using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RevStackCore.Pattern;
using SmartDevices.Models;
using SmartDevices.Models.Interfaces;
using SmartDevices.Models.ViewModels;

namespace SmartDevices.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        private readonly IAllRooms _allRooms;
        private readonly IAllHouses _allHouses;
        public RoomsController(IAllRooms allRooms, IAllHouses allHouses)
        {
            _allRooms = allRooms;
            _allHouses = allHouses;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Комнаты";
            HousesListViewModel obj = new();
            obj.AllRooms = _allRooms.GetRooms(int.Parse(User.Identity.Name));
            obj.AllHouses = _allHouses.GetHouses(int.Parse(User.Identity.Name));
            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _allRooms.DeleteRoom(id);
            return RedirectToAction("List");
        }
        public ViewResult Add()
        {
            ViewBag.Title = "Добавление";
            RoomsListViewModel obj = new();
            obj.AllRooms = _allRooms.GetRooms(int.Parse(User.Identity.Name));
            obj.AllHouses = _allHouses.GetHouses(int.Parse(User.Identity.Name));
            return View(obj);
        }
        [HttpPost]
        public ActionResult Add(Room room, int houseId)
        {
            room.House = _allHouses.GetObjectHouse(houseId);
            _allRooms.AddRoom(room);
            return RedirectToAction("Complete");
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            RoomsListViewModel obj = new();
            obj.CurrentRoom = _allRooms.GetObjectRoom(id);
            obj.AllRooms = _allRooms.GetRooms(int.Parse(User.Identity.Name));
            obj.AllHouses = _allHouses.GetHouses(int.Parse(User.Identity.Name));
            return View(obj);
        }
        [HttpPost]
        public ActionResult EditRoom(Room room, int houseId)
        {
            room.House = _allHouses.GetObjectHouse(houseId);
            _allRooms.EditRoom(room);
            return RedirectToAction("Complete");
        }
        public ViewResult Complete()
        {
            return View();
        }
    }
}
