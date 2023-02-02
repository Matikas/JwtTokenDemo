using JwtTokenDemo.DAL;
using System.Security.Cryptography;
using System.Text;

namespace JwtTokenDemo.BL
{
    public class AccountsService : IAccountsService
    {
        private readonly IJwtRepository _jwtRepository;

        public AccountsService(IJwtRepository jwtRepository)
        {
            _jwtRepository = jwtRepository;
        }

        public (bool, Account) Login(string username, string password)
        {
            var account = _jwtRepository.GetAccount(username);
            if (account == null)
            {
                return (false, null);
            }

            if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return (true, account);
            }
            else
            {
                return (false, null);
            }
        }

        public Account SignupNewAccount(string username, string password)
        {
            var account = CreateAccount(username, password);
            _jwtRepository.SaveAccount(account);
            return account;
        }

        private Account CreateAccount(string username, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var account = new Account
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            return account;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
