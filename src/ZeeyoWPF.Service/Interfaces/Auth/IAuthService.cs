using ZeeyoWPF.Service.Models.LoginModels;
using ZeeyoWPF.Service.Models.Response;

namespace ZeeyoWPF.Service.Interfaces.Auth;

public interface IAuthService
{
    public Task<Response> LoginAsync(LoginModel loginModel);
}


