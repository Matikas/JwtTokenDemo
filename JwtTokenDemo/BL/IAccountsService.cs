namespace JwtTokenDemo.BL
{
    public interface IAccountsService
    {
        Account SignupNewAccount(string username, string password);
        (bool, Account) Login(string username, string password);
    }
}
