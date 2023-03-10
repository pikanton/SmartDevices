namespace SmartDevices.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string Image { get; set; }
        public ushort? Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Time { get; set; }
        public virtual Room Room { get; set; }
    }
}
