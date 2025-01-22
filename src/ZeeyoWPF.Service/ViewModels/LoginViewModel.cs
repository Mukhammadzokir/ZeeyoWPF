using System.ComponentModel;
using ZeeyoWPF.Service.Services.Auth;
using ZeeyoWPF.Service.Models.LoginModels;
using ZeeyoWPF.Service.ViewModels.Commons;

namespace ZeeyoWPF.Service.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private string _password;
    private string _phoneNumber;
    private string _loginMessage;
    private readonly AuthService _authService;
    public LoginViewModel()
    {
        _authService = new AuthService();
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
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

    public async Task<bool> LoginAsync()
    {
        var loginModel = new LoginModel
        {
            PhoneNumber = PhoneNumber,
            Password = Password,
        };

        try
        {
            var response = await _authService.LoginAsync(loginModel);
            if (response.Data != null)
            {
                LoginMessage = "Login Successfully";
                return true;
            }
            else
            {
                LoginMessage = "Login failed. No vailed token was returned.";
                return false;
            }
        }
        catch (Exception ex)
        {
            LoginMessage = $"Login failed. Error:  {ex.Message}";
            return false;
        }
    }

}
