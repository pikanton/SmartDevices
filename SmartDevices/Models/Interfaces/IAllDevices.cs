namespace SmartDevices.Models.Interfaces
{
    public interface IAllDevices
    {
        IEnumerable<Device> GetDevices(int userId);
        Device GetObjectDevice(int deviceId);
        void DeleteDevice(int deviceId);
        void AddDevice(Device device);
        void EditDevice(Device device);
        void EditActivity(int deviceId);
    }
}
