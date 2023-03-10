namespace SmartDevices.Models.Interfaces
{
    public interface IAllUsers
    {
        IEnumerable<User> GetUsers { get; }
        User GetObjectUser(int userId);
        User GetUserByIdentity(User user);
        void DeleteUser(int userId);
        void AddUser(User user);
        void EditUser(User user);
    }
}
