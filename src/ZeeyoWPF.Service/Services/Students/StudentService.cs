using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using ZeeyoWPF.Service.Models.Response;
using ZeeyoWPF.Service.Interfaces.Students;
using ZeeyoWPF.Service.Models.StudentModels;

namespace ZeeyoWPF.Service.Services.Students;

public class StudentService : IStudentService
{
    private HttpClient _httpClient;

    public StudentService()
    {
        _httpClient = Extensions.CollectionExtensions.GetHttpClient();
    }
    public async Task<Response> AddAsync(StudentForCreationDto dto)
    {
        try
        {
            Extensions.CollectionExtensions.AddAuthorizationHeader();

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = await _httpClient.PostAsync($"Students", content);

            var jsonString = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response>(jsonString);

            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<Response> AddProfilePhotoAsync(long studentId, IFormFile formFile)
    {
        throw new NotImplementedException();
    }

    public Task<Response> ModifyAsync(long id, StudentForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Response> RetrieveByPhoneNumberAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }
}
