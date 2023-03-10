using SmartDevices.Models;

namespace SmartDevices.Models.ViewModels
{
    public class HousesListViewModel
    {
        public IEnumerable<House> AllHouses { get; set; }
        public IEnumerable<Room> AllRooms { get; set; }
        public House CurrentHouse { get; set; }
    }
}
