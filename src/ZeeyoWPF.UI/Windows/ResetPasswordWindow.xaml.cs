using System.Windows;
using System.Net.Http;
using ZeeyoWPF.Service.ViewModels;

namespace ZeeyoWPF.UI.Windows;

public partial class ResetPasswordWindow : Window
{
    private readonly HttpClient _httpClient;
    private readonly ResetPasswordViewModel _resetPasswordViewModel;

    public ResetPasswordWindow()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
        _resetPasswordViewModel = new ResetPasswordViewModel();

        this.DataContext = _resetPasswordViewModel;
    }

    private async void ChangeBtnClick(object sender, RoutedEventArgs e)
    {
        var result = await _resetPasswordViewModel.ResetPasswordAsync();
        if(result == true)
        {
            MessageBox.Show(_resetPasswordViewModel.LoginMessage);
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close(); ;
        }
        else
        {
            MessageBox.Show(_resetPasswordViewModel?.LoginMessage);
        }
    }
    private void ReturnBackBtnClick(object sender, RoutedEventArgs e)
    {
        VerifyEmailWindow verifyEmailWindow = new VerifyEmailWindow();
        verifyEmailWindow.Show();
        this.Close();
    }
}
