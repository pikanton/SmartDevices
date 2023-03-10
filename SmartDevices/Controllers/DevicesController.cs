using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartDevices.Models;
using SmartDevices.Models.Interfaces;
using SmartDevices.Models.ViewModels;

namespace SmartDevices.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        private readonly IAllDevices _allDevices;
        private readonly IAllRooms _allRooms;
        private readonly IAllHouses _allHouses;
        public DevicesController(IAllDevices allDevices, IAllRooms allRooms, IAllHouses allHouses)
        {
            _allDevices = allDevices;
            _allRooms = allRooms;
            _allHouses = allHouses;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Устройства";
            DevicesListViewModel obj = new();
            obj.AllDevices = _allDevices.GetDevices(int.Parse(User.Identity.Name));
            obj.AllRooms = _allRooms.GetRooms(int.Parse(User.Identity.Name));
            obj.AllHouses = _allHouses.GetHouses(int.Parse(User.Identity.Name));
            return View(obj);
        }
        public ViewResult Add()
        {
            ViewBag.Title = "Добавление";
            DevicesListViewModel obj = new();
            obj.AllRooms = _allRooms.GetRooms(int.Parse(User.Identity.Name));
            return View(obj);
        }
        public ViewResult Complete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Device device, int roomId)
        {
            device.Room = _allRooms.GetObjectRoom(roomId);
            _allDevices.AddDevice(device);
            return RedirectToAction("Complete");
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            DevicesListViewModel obj = new();
            obj.CurrentDevice = _allDevices.GetObjectDevice(id);
            obj.AllRooms = _allRooms.GetRooms(int.Parse(User.Identity.Name));
            return View(obj);
        }
        [HttpPost]
        public ActionResult EditDevice(Device device, int roomId)
        {
            device.Room = _allRooms.GetObjectRoom(roomId);
            _allDevices.EditDevice(device);
            return RedirectToAction("Complete");
        }
        [HttpPost]
        public ActionResult EditActivity(int id)
        {
            _allDevices.EditActivity(id);
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _allDevices.DeleteDevice(id);
            return RedirectToAction("List");
        }

    }
}
