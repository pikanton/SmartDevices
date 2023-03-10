namespace SmartDevices.Models.ViewModels
{
    public class RoomsListViewModel
    {
        public IEnumerable<House> AllHouses { get; set; }
        public IEnumerable<Room> AllRooms { get; set; }
        public Room CurrentRoom { get; set; }
    }
}
