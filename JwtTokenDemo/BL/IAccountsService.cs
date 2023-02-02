namespace JwtTokenDemo.BL
{
    public interface IAccountsService
    {
        Account SignupNewAccount(string username, string password);
        bool Login(string username, string password);
    }
}
