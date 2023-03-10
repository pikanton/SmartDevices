using SmartDevices.Models;

namespace SmartDevices.Models.ViewModels
{
    public class DevicesListViewModel
    {
        public IEnumerable<Device> AllDevices { get; set; }
        public IEnumerable<Room> AllRooms { get; set; }
        public IEnumerable<House> AllHouses { get; set; }
        public Device CurrentDevice { get; set; }
    }
}
