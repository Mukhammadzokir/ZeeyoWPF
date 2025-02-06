namespace ZeeyoWPF.Service.Models.StudentModels;

public class StudentForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelegramUserName { get; set; }
    public long BranchId { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
