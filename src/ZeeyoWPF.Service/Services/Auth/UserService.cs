using System.Text;
using Newtonsoft.Json;
using ZeeyoWPF.Service.Models.Response;
using ZeeyoWPF.Service.Interfaces.Auth;
using ZeeyoWPF.Service.Models.ResetPasswordModels;

namespace ZeeyoWPF.Service.Services.Auth;

public class UserService : IUserService
{
    private HttpClient _httpClient;

    public UserService()
    {
        _httpClient = Extensions.CollectionExtensions.GetHttpClient();
    }
    
    public async Task<Response> CheckUserAsync(string phoneNumberOrEamil)
    {
        try
        {
            Extensions.CollectionExtensions.AddAuthorizationHeader();

            var encodedParam = Uri.EscapeDataString(phoneNumberOrEamil);

            var requestUrl = $"Users/check-user?check-user={encodedParam}";

            var responseMessage = await _httpClient.GetAsync(requestUrl);

            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response>(jsonString);

            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Response> ResetPasswordAsync(ResetPasswordModel resetPasswordModel)
    {
        try
        {
            Extensions.CollectionExtensions.AddAuthorizationHeader();

            var json = JsonConvert.SerializeObject(resetPasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = await _httpClient.PutAsync($"Users/forget-password", content);

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
