using Microsoft.EntityFrameworkCore;
using SmartDevices.Models;
using SmartDevices.Models.Interfaces;

namespace SmartDevices.Repository
{
    public class UserRepository : IAllUsers
    {
        private readonly AppDBContext appDBContent;
        public UserRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<User> GetUsers => appDBContent.User;

        public User GetObjectUser(int userId) => GetUsers.FirstOrDefault(p => p.Id == userId);
        public void DeleteUser(int userId)
        {
            User user = GetObjectUser(userId);
            appDBContent.User.Remove(user);
            appDBContent.SaveChanges();
        }
        public void AddUser(User user)
        {
            appDBContent.User.Add(user);
            appDBContent.SaveChanges();
        }

        public void EditUser(User user)
        {
            appDBContent.User.Update(user);
            appDBContent.SaveChanges();
        }

        public User GetUserByIdentity(User user)=> appDBContent.User.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
    }
}
