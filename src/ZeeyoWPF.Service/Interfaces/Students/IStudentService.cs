using Microsoft.AspNetCore.Http;
using ZeeyoWPF.Service.Models.Response;
using ZeeyoWPF.Service.Models.StudentModels;

namespace ZeeyoWPF.Service.Interfaces.Students;

public interface IStudentService
{
    Task<Response> AddAsync(StudentForCreationDto dto);
    Task<Response> ModifyAsync(long id, StudentForUpdateDto dto);
    Task<Response> RetrieveByPhoneNumberAsync(string phoneNumber);
    Task<Response> AddProfilePhotoAsync(long studentId, IFormFile formFile);

}
