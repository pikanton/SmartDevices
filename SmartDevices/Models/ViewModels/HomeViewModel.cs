using SmartDevices.Models;

namespace SmartDevices.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Device> ActiveDevices { get; set; }
    }
}
