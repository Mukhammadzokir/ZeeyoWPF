using ZeeyoWPF.Service.Models;

namespace ZeeyoWPF.Service.Interfaces.Auth;

public interface IAuthService
{
    public Task<LoginViewModel> LoginAsync(LoginModel loginModel);
}


