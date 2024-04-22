namespace NetPromoterScoreAPI.Interfaces
{
    public interface ILoginRepository
    {
        bool userLogin(string email, string password);
    }
}
