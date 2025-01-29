using ZeeyoWPF.Service.Models.Response;

namespace ZeeyoWPF.Service.Interfaces.Auth;

public interface IUserService
{
    public Task<Response> CheckUserAsync(string phoneNumberOrEamil);
}
