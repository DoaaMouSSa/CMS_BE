using cms_be.Models;

namespace cms_be.AuthServices
{
    public interface IAuthService
    {
        Task<Response<AuthModel>> RegisterAsync(RegisterModel registerModel);
        Task<Response<AuthModel>> LoginAsync(LoginModel loginModel);
    }
}
