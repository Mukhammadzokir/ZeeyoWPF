using ZeeyoWPF.Service.Models.EmailModels;
using ZeeyoWPF.Service.Models.Response;

namespace ZeeyoWPF.Service.Interfaces.Auth;

public interface IEmailService
{
    public Task<Response> SendCodeByEmailAsync(string email);

    public Task<Response> VerifyCodeAsync(VerifyEmailModel emailModel);
}
