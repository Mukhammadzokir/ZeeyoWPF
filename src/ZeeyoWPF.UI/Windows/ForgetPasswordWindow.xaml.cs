using System.Windows;
using System.Net.Http;
using ZeeyoWPF.Service.ViewModels;
using ZeeyoWPF.Service.Services.Auth;
using ZeeyoWPF.Service.Interfaces.Auth;

namespace ZeeyoWPF.UI.Windows
{
    public partial class ForgetPasswordWindow : Window
    {
        private readonly HttpClient _httpClient;
        private readonly IEmailService _emailService;
        private readonly VerifyEmailViewModel _verifyEmailViewModel;
        public ForgetPasswordWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _emailService = new EmailService();
            _verifyEmailViewModel = new VerifyEmailViewModel();

            this.DataContext = _verifyEmailViewModel;
        }

        private async void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await _verifyEmailViewModel.SendCodeByEmailAsync();
            if (result)
            {
                MessageBox.Show(_verifyEmailViewModel.LoginMessage);
            }
            else
            {
                MessageBox.Show(_verifyEmailViewModel.LoginMessage);
            }

            VerifyEmailWindow verifyEmailWindow = new VerifyEmailWindow();
            verifyEmailWindow.Show();
            this.Close();
        }
        private void ReturnBackButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            this.Close();
        }
    }
}
