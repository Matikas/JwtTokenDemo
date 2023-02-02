namespace JwtTokenDemo.DAL
{
    public interface IJwtRepository
    {
        void SaveAccount(Account account);
        Account GetAccount(string username);
    }
}
