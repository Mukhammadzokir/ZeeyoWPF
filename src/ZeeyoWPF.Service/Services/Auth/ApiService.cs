using Newtonsoft.Json;
using System.Net.Http.Json;
using ZeeyoWPF.Service.Services.Helpers;

namespace ZeeyoWPF.Service.Services.Auth
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = Extensions.CollectionExtensions.GetHttpClient();
        }

        public async Task<LoginResultDto> LoginAsync(string phoneNumber, string password)
        {
            var userLoginDto = new UserLoginDto
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
                var loginResult = JsonConvert.DeserializeObject<LoginResultDto>(responseString);

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

    public class UserLoginDto
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class LoginResultDto
    {
        public string Token { get; set; }
    }

}
