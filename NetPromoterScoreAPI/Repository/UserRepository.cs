using Microsoft.EntityFrameworkCore;
using NetPromoterScoreAPI.Data;
using NetPromoterScoreAPI.DTOs;
using NetPromoterScoreAPI.Interfaces;
using NetPromoterScoreAPI.Models;

namespace NetPromoterScoreAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.Include(u => u.Calification).OrderBy(p => p.IdUser).ToList();
        }

        public User GetUser(int id) 
        {
            return _context.Users.Include(u => u.Calification).Where(p => p.IdUser == id).FirstOrDefault();
        }

        public int CreateUser(User user)
        {
            int result = -1;
            if (user == null)
            {
                result = 0;
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                result = user.IdUser;
            }
            return result;
        }

        public int UpdateUser(User user)
        {
            var y = _context.Users
                .Include(u => u.Calification)
                .Where(x => x.IdUser == user.IdUser)
                .FirstOrDefault();

            if (y != null)
            {
                y.CC = user.CC;
                y.Name = user.Name;
                y.Email = user.Email;
                y.Password = user.Password;
                y.Role = user.Role;

                if (y.Calification != null)
                {
                    y.Calification.Score = user.Calification?.Score ?? y.Calification.Score;
                }

                _context.SaveChanges();
                return y.IdUser;
            }

            return -1;
        }

        public int DeleteUser(int id)
        {
            if (id == 0)
            {
                return -1;
            }
            var x = _context.Users.Where(x => x.IdUser == id).FirstOrDefault();
            if (x != null)
            {
                _context.Users.Remove(x);
                _context.SaveChanges();
                return x.IdUser;
            }
            return 0;
        }

        public bool userExists(int id)
        {
            return _context.Users.Any(p => p.IdUser == id);
        }
    }
}
