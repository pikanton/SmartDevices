using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using SmartDevices.Models;
using SmartDevices.Models.Interfaces;

namespace SmartDevices.Repository
{
    public class HouseRepository : IAllHouses
    {
        private readonly AppDBContext appDBContent;
        public HouseRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<House> GetHouses(int userId) => appDBContent.House.Include(c => c.User).Where(a => a.User.Id == userId);

        public House GetObjectHouse(int houseId) => appDBContent.House.Include(c => c.User).FirstOrDefault(p => p.Id == houseId);
        public void DeleteHouse(int houseId)
        {
            House house = GetObjectHouse(houseId);
            appDBContent.House.Remove(house);
            appDBContent.SaveChanges();
        }
        public void AddHouse(House house)
        {
            appDBContent.House.Add(house);
            appDBContent.SaveChanges();
        }

        public void EditHouse(House house)
        {
            appDBContent.House.Update(house);
            appDBContent.SaveChanges();
        }
    }
}
