using System.Windows;
using System.Net.Http;
using ZeeyoWPF.Service.ViewModels;

namespace ZeeyoWPF.UI.Windows;

/// <summary>
/// Interaction logic for VerifyPhoneNumberWindow.xaml
/// </summary>
public partial class VerifyPhoneNumberWindow : Window
{
    private readonly HttpClient _httpClient;
    private readonly VerifyEmailViewModel _verifyEmailViewModel;
    public VerifyPhoneNumberWindow()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
        _verifyEmailViewModel = new VerifyEmailViewModel();

        this.DataContext = _verifyEmailViewModel;
    }
    private async void VeriyfBtn_Click(object sender, RoutedEventArgs e)
    {
        var result = await _verifyEmailViewModel.VerifySmsCodeAsync();
        if (result == true)
        {
            ResetPasswordWindow resetPasswordWindow = new ResetPasswordWindow();
            resetPasswordWindow.Show();
            this.Close();
        }
        else
        {
            MessageBox.Show(_verifyEmailViewModel.LoginMessage);
        }
    }

    private void ResendBtn_Click(object sender, RoutedEventArgs e)
    {
        ForgetPasswordWindow forgetPasswordWindow = new ForgetPasswordWindow();
        forgetPasswordWindow.Show();
        this.Close();
    }

    private void ReturnBackBtn_Click(object sender, RoutedEventArgs e)
    {
        ForgetPasswordWindow forgetPasswordWindow = new ForgetPasswordWindow();
        forgetPasswordWindow.Show();
        this.Close();
    }
}