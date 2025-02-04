using ZeeyoWPF.Service.Models.Response;
using ZeeyoWPF.Service.Models.ResetPasswordModels;

namespace ZeeyoWPF.Service.Interfaces.Auth;

public interface IUserService
{
    public Task<Response> CheckUserAsync(string phoneNumberOrEamil);    
    public Task<Response> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
}
