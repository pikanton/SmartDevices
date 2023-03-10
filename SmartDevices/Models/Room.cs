namespace SmartDevices.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int? SquareMeters { get; set; }
        public House House { get; set; }

    }
}
