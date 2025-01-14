using System.Net.Http.Headers;
using ZeeyoWPF.Service.Services.Helpers;

namespace ZeeyoWPF.Service.Services.Extensions
{
    public static class CollectionExtensions
    {
        private static readonly HttpClient _httpClient;

        static CollectionExtensions()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7196/api/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
        }

        public static void AddAuthorizationHeader()
        {
            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
            }

            if (!string.IsNullOrEmpty(TokenHelper.apiToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenHelper.apiToken);
            }

            //#region Language
            //if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
            //{
            //    _httpClient.DefaultRequestHeaders.Remove("Accept-Language");
            //}

            //if (!string.IsNullOrEmpty(LanguageHelper.CurrentLanguage))
            //{
            //    _httpClient.DefaultRequestHeaders.Add("Accept-Language", LanguageHelper.CurrentLanguage);
            //}
            //#endregion

        }

        public static HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }

}
