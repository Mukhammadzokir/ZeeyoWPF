namespace ZeeyoWPF.Service.Models.ResetPasswordModels;

public class ResetPasswordModel
{
    public string PhoneNumberOrEmail { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}
