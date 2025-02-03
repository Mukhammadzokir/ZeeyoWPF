using System.Text;
using Newtonsoft.Json;
using ZeeyoWPF.Service.Interfaces.Auth;
using ZeeyoWPF.Service.Models.Response;
using ZeeyoWPF.Service.Models.EmailModels;

namespace ZeeyoWPF.Service.Services.Auth;

public class EmailService : IEmailService
{
    private HttpClient _httpClient;

    public EmailService()
    {
        _httpClient = Extensions.CollectionExtensions.GetHttpClient();
    }

    public async Task<Response> SendCodeByEmailAsync(string email)
    {
        try
        {
            Extensions.CollectionExtensions.AddAuthorizationHeader();

            var json = JsonConvert.SerializeObject(email);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync($"Email/send-code", content);

            var jsonString = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response>(jsonString);

            return response;
        }
        catch(Exception ex) 
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Response> VerifyCodeAsync(VerifyEmailModel emailModel)
    {
        try
        {
            Extensions.CollectionExtensions.AddAuthorizationHeader();

            var json = JsonConvert.SerializeObject(emailModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync($"Email/verify-code", content);

            var jsonString = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response>(jsonString);

            return response;
        }
        catch( Exception ex) 
        {
            throw new Exception(ex.Message);
        }
    }
}
