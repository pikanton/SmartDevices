namespace SmartDevices.Models.Interfaces
{
    public interface IAllRooms
    {
        IEnumerable<Room> GetRooms(int userId);
        Room GetObjectRoom(int roomId);
        void DeleteRoom(int roomId);
        void AddRoom(Room room);
        void EditRoom(Room room);
    }
}
