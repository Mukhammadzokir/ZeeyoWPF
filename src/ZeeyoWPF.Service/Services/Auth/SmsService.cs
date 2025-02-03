using System.Text;
using Newtonsoft.Json;
using ZeeyoWPF.Service.Interfaces.Auth;
using ZeeyoWPF.Service.Models.Response;
using ZeeyoWPF.Service.Models.SmsModels;

namespace ZeeyoWPF.Service.Services.Auth;

public class SmsService : ISmsService
{
    private HttpClient _httpClient;

    public SmsService()
    {
        _httpClient = Extensions.CollectionExtensions.GetHttpClient();
    }

    public async Task<Response> SendCodeByPhoneNumberAsync(string phoneNumber)
    {
        try
        {
            Extensions.CollectionExtensions.AddAuthorizationHeader();

            var json = JsonConvert.SerializeObject(phoneNumber);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync($"Sms/send-code", content);

            var jsonString = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response>(jsonString);

            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Response> VerifyCodeAsync(VerifyPhoneNumberModel phoneNumberModel)
    {
        try
        {
            Extensions.CollectionExtensions.AddAuthorizationHeader();

            var json = JsonConvert.SerializeObject(phoneNumberModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync($"Sms/verify-code", content);

            var jsonString = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response>(jsonString);

            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
