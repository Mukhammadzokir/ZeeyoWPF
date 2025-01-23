using ZeeyoWPF.Service.Services.Auth;
using ZeeyoWPF.Service.Models.EmailModels;
using ZeeyoWPF.Service.ViewModels.Commons;
using ZeeyoWPF.Service.Properties;

namespace ZeeyoWPF.Service.ViewModels;

public class VerifyEmailViewModel : BaseViewModel
{
    private string _code;
    private string _email;
    private string _loginMessage;
    private readonly EmailService _emailService;

    public VerifyEmailViewModel()
    {
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

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
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


    public async Task<bool> SendCodeByEmailAsync()
    {
        var email = Email;
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
