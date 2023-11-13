using ADars1.Models;

namespace ADars1.Services
{
    public interface IAuthService
    {
        ValueTask<string> Login(LoginRequest request);
    }
}
