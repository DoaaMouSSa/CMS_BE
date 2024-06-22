using cms_be.DataContext;
using cms_be.Models;
using Microsoft.AspNetCore.Identity;

namespace cms_be.AuthService
{
    public class AuthService:IAuthService
    {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly ApplicationDbContext _context;

            public AuthService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
            {
                _userManager = userManager;
                _context = context;
            }

            public async Task<Response<AuthModel>> LoginAsync(LoginModel loginModel)
            {
                Response<AuthModel> response = new Response<AuthModel>();
                AuthModel authModel;

                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user is not null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, loginModel.Password);
                    if (result)
                    {

                        authModel = new AuthModel
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            IsAuthenticated = true,
                            IsAdmin = user.IsAdmin,
                        };
                        response.Message = "تم تسجيل الدخول بنجاح";
                        response.IsSuccess = true;
                        response.Payload = authModel;

                    }
                    else
                    {
                        response.Message = "يوجد خطأ باسم المستخدم او كلمه السر";
                        response.IsSuccess = false;
                    }
                }
                return response;
            }

            public async Task<Response<AuthModel>> RegisterAsync(RegisterModel registerModel)
            {
                Response<AuthModel> response = new Response<AuthModel>();
                AuthModel authModel;
                ApplicationUser user = new ApplicationUser()
                {
                    Email = registerModel.Email,
                    UserName = registerModel.UserName,
                    PhoneNumber = registerModel.Phone,
                    IsAdmin = registerModel.IsAdmin,
                };
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (!result.Succeeded)
                {
                    response.Message = "حدث خطأ";
                    response.IsSuccess = false;
                }
                else if (result.Succeeded && user.IsAdmin == true)
                {
                    var resultRole = await _userManager.AddToRoleAsync(user, "Admin");
                }
                else if (result.Succeeded && user.IsAdmin == false)
                {
                    var resultRole = await _userManager.AddToRoleAsync(user, "User");
                }
                authModel = new AuthModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsAuthenticated = true,
                    IsAdmin = user.IsAdmin,
                };
                response.Message = "تم تسجيل الدخول بنجاح";
                response.IsSuccess = true;
                response.Payload = authModel;

                return response;

            }
        }
}
