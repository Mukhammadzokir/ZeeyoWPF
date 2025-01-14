using Newtonsoft.Json;
using System.Text;
using ZeeyoWPF.Service.Interfaces.Auth;
using ZeeyoWPF.Service.Models;

namespace ZeeyoWPF.Service.Services.Auth;

public class AuthService : IAuthService
{
    private HttpClient _httpClient;

    public AuthService()
    {
        _httpClient = Extensions.CollectionExtensions.GetHttpClient();
    }
    public async Task<LoginViewModel> LoginAsync(LoginModel loginModel)
    {
        try
        {
            Extensions.CollectionExtensions.AddAuthorizationHeader();
            //_httpClient.DefaultRequestHeaders.Add("Accept-Language", LanguageHelper.CurrentLanguage);

            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync($"Auth/login", content);

            var jsonString = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<LoginViewModel>(jsonString);

            return response;
        }
        catch
        {
            return null;
        }
    }
}

