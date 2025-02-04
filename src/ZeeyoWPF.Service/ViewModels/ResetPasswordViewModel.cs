using ZeeyoWPF.Service.Properties;
using ZeeyoWPF.Service.Services.Auth;
using ZeeyoWPF.Service.ViewModels.Commons;
using ZeeyoWPF.Service.Models.ResetPasswordModels;

namespace ZeeyoWPF.Service.ViewModels;

public class ResetPasswordViewModel : BaseViewModel
{
    private string _newPassword;
    private string _loginMessage;
    private string _confirmPassword;
    private readonly UserService _userService;
    public ResetPasswordViewModel()
    {
        _userService = new UserService();
    }

    public string NewPassword
    {
        get => _newPassword;
        set
        {
            _newPassword = value;
            OnPropertyChanged(nameof(NewPassword));
        }
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            _confirmPassword = value;
            OnPropertyChanged(nameof(ConfirmPassword));
        }
    }

    public string LoginMessage
    {
        get => _loginMessage;
        set
        {
            _loginMessage = value;
            OnPropertyChanged(nameof(LoginMessage));
        }
    }

    public async Task<bool> ResetPasswordAsync()
    {
        var resetPasswordModel = new ResetPasswordModel()
        {
            PhoneNumberOrEmail = Settings.Default.EmailOrNumber,
            NewPassword = NewPassword,
            ConfirmPassword = ConfirmPassword,
        };
        try
        {
            var response = await _userService.ResetPasswordAsync(resetPasswordModel);
            if (response.StatusCode == 200)
            {
                LoginMessage = "Password changed successfully";
                return true;
            }
            else
            {
                LoginMessage = response.Message;
                return false;
            }
        }
        catch (Exception ex)
        {
            LoginMessage = $"Reset password failed. Error:  {ex.Message}";
            return false;
        }
    }
}