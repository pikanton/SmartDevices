using Microsoft.EntityFrameworkCore;
using SmartDevices.Models;
using SmartDevices.Models.Interfaces;

namespace SmartDevices.Repository
{
    public class RoomRepository : IAllRooms
    {
        private readonly AppDBContext appDBContent;
        public RoomRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Room> GetRooms(int userId) => appDBContent.Room.Include(c => c.House)
                                                              .ThenInclude(b => b.User).Where(a => a.House.User.Id == userId);
        public Room GetObjectRoom(int roomId) => appDBContent.Room.Include(c => c.House)
                                                              .ThenInclude(b => b.User)
                                                              .FirstOrDefault(p => p.Id == roomId);

        public void AddRoom(Room room)
        {
            appDBContent.Room.Update(room);
            appDBContent.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            Room room = GetObjectRoom(roomId);
            appDBContent.Room.Remove(room);
            appDBContent.SaveChanges();
        }

        public void EditRoom(Room room)
        {
            appDBContent.Room.Update(room);
            appDBContent.SaveChanges();

        }

        
    }
}
