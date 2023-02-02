namespace JwtTokenDemo.BL
{
    public interface IJwtService
    {
        string GetJwtToken(string username, int accountId);
    }
}
