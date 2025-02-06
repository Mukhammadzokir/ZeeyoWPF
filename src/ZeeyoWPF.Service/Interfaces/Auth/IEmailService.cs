using ZeeyoWPF.Service.Models.Response;
using ZeeyoWPF.Service.Models.EmailModels;

namespace ZeeyoWPF.Service.Interfaces.Auth;

public interface IEmailService
{
    public Task<Response> SendCodeByEmailAsync(string email);
    public Task<Response> VerifyEmailCodeAsync(VerifyEmailModel emailModel);
}
