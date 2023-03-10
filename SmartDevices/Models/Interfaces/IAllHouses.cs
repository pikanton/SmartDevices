namespace SmartDevices.Models.Interfaces
{
    public interface IAllHouses
    {
        IEnumerable<House> GetHouses(int userId);
        House GetObjectHouse(int houseId);
        void DeleteHouse(int houseId);
        void AddHouse(House house);
        void EditHouse(House house);
    }
}
