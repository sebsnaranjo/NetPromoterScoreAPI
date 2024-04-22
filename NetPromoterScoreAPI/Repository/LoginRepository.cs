using NetPromoterScoreAPI.Data;
using NetPromoterScoreAPI.Interfaces;

namespace NetPromoterScoreAPI.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;

        public LoginRepository(DataContext context)
        {
            _context = context;
        }

        public bool userLogin(string email, string password)
        {
            var user = _context.Users.Where(u => u.Email == email).FirstOrDefault();

            if(user == null)
            {
                return false;
            }

            if(user.Password != password)
            {
                return false;
            }

            return true;
        }
    }
}
