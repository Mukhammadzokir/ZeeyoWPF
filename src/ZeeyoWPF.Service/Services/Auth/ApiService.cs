using Newtonsoft.Json;
using System.Net.Http.Json;
using ZeeyoWPF.Service.Models.LoginModels;
using ZeeyoWPF.Service.Services.Helpers;

namespace ZeeyoWPF.Service.Services.Auth;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = Extensions.CollectionExtensions.GetHttpClient();
    }

    public async Task<LoginViewModel> LoginAsync(string phoneNumber, string password)
    {
        var userLoginDto = new LoginModel
        {
            PhoneNumber = phoneNumber,
            Password = password
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("Auth/login", userLoginDto);

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new UnauthorizedAccessException($"Login failed: {response.StatusCode} - {responseContent}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var loginResult = JsonConvert.DeserializeObject<LoginViewModel>(responseString);

            if (loginResult != null && !string.IsNullOrEmpty(loginResult.Token))
            {
                TokenHelper.apiToken = loginResult.Token;
                Extensions.CollectionExtensions.AddAuthorizationHeader();
            }
            else
            {
                throw new UnauthorizedAccessException("Login successful but token is missing.");
            }

            return loginResult;
        }
        catch (HttpRequestException)
        {
            throw new UnauthorizedAccessException("Неправильный логин или пароль");
        }
    }
}