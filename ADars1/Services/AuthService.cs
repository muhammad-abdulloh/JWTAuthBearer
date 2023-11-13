using ADars1.Models;
using Microsoft.EntityFrameworkCore;

namespace ADars1.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITokenService _tokenSerice;

        public AuthService(ApplicationDbContext applicationDbContext, ITokenService tokenService)
        {
            _dbContext = applicationDbContext;
            _tokenSerice = tokenService;
        }
        public async ValueTask<string> Login(LoginRequest request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName); 

            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else if (user.PasswordHash != request.Password)
            {
                throw new Exception("Password is wrong");
            }

            return _tokenSerice.Generate(user.UserName);

        }
    }
}
