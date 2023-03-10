using Microsoft.EntityFrameworkCore;
using SmartDevices.Models;
using SmartDevices.Models.Interfaces;

namespace SmartDevices.Repository
{
    public class DeviceRepository : IAllDevices
    {
        private readonly AppDBContext appDBContent;
        public DeviceRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Device> GetDevices(int userId) => appDBContent.Device.Include(c => c.Room)
                                                                     .ThenInclude(b => b.House)
                                                                     .ThenInclude(a => a.User)
                                                                     .Where(a => a.Room.House.User.Id == userId);
        public Device GetObjectDevice(int deviceId) => appDBContent.Device.Include(c => c.Room)
                                                                     .ThenInclude(b => b.House)
                                                                     .ThenInclude(a => a.User).FirstOrDefault(p => p.Id == deviceId);
        public void DeleteDevice(int deviceId)
        {
            Device device = GetObjectDevice(deviceId);
            appDBContent.Device.Remove(device);
            appDBContent.SaveChanges();
        }
        public void AddDevice(Device device)
        {
            appDBContent.Device.Add(device);
            appDBContent.SaveChanges();
        }

        public void EditDevice(Device device)
        {
            appDBContent.Device.Update(device);
            appDBContent.SaveChanges();
        }

        public void EditActivity(int deviceId)
        {
            Device currDevice = GetObjectDevice(deviceId);
            currDevice.IsActive = !currDevice.IsActive;
            currDevice.Time = DateTime.Now;
            appDBContent.Device.Update(currDevice);
            appDBContent.SaveChanges();
        }
    }
}
