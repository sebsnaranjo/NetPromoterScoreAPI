using NetPromoterScoreAPI.DTOs;
using NetPromoterScoreAPI.Models;

namespace NetPromoterScoreAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        int CreateUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int id);
        bool userExists(int id);
    }
}
