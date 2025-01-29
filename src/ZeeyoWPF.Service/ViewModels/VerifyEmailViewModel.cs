using ZeeyoWPF.Service.Properties;
using ZeeyoWPF.Service.Services.Auth;
using ZeeyoWPF.Service.Models.EmailModels;
using ZeeyoWPF.Service.ViewModels.Commons;

namespace ZeeyoWPF.Service.ViewModels;

public class VerifyEmailViewModel : BaseViewModel
{
    private string _code;
    private string _loginMessage;
    private string _emailOrPhoneNumber;
    private readonly UserService _userService;
    private readonly EmailService _emailService;

    public VerifyEmailViewModel()
    {
        _userService = new UserService();
        _emailService = new EmailService();
    }

    public string Code
    {
        get => _code;
        set
        {
            _code = value;
            OnPropertyChanged(nameof(Code));
        }
    }

    public string EmailOrPhoneNumber
    {
        get => _emailOrPhoneNumber;
        set
        {
            _emailOrPhoneNumber = value;
            OnPropertyChanged(nameof(EmailOrPhoneNumber));
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

    public async Task<bool> CheckUserAsync()
    {
        var emailOrPhoneNumber = EmailOrPhoneNumber;
        try
        {
            var response = await _userService.CheckUserAsync(emailOrPhoneNumber);
            if(response.Data is false)
            {
                LoginMessage = "Please! Enter your email or phone number";
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            LoginMessage = $"Email or phone number failed. Error:  {ex.Message}";
            return false;
        }
    }

    public async Task<string> CheckEmailOrPhoneNumber()
    {
        var emailOrPhoneNumber = EmailOrPhoneNumber;
        if (emailOrPhoneNumber.Contains("+998"))
            return "phone";
        else if (emailOrPhoneNumber.Contains(".com") && emailOrPhoneNumber.Contains("@"))
            return "email";
        else
            return "error";
    }

    public async Task<bool> SendCodeByEmailAsync()
    {
        var email = EmailOrPhoneNumber;
        Settings.Default.Email = email;
        Settings.Default.Save();
        try
        {
            var response = await _emailService.SendCodeByEmailAsync(email);
            if (response.Data != null)
            {
                LoginMessage = "Code sent successfully";
                return true;
            }
            else
            {
                LoginMessage = "Code not sent to email address ";
                return false;
            }
        }
        catch (Exception ex)
        {
            LoginMessage = $"Email failed. Error:  {ex.Message}";
            return false;
        }
        
    }

    public async Task<bool> VerifyCodeAsync()
    {
        var verifyEmailModel = new VerifyEmailModel()
        {
            Code = Code,
            Email = Settings.Default.Email,
        };

        try
        {
            var response = await _emailService.VerifyCodeAsync(verifyEmailModel);
            if (response.Data.Equals(true))
            {
                LoginMessage = "Email verified successfully";
                return true;
            }
            else
            {
                LoginMessage = "verification failed.";
                return false;
            }
        }
        catch (Exception ex)
        {
            LoginMessage = $"Verification failed. Error:  {ex.Message}";
            return false;
        }
    }
}
