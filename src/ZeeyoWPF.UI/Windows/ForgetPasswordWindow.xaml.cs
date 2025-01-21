using System.Net.Http;
using System.Windows;
using ZeeyoWPF.Service.Services.Auth;
using ZeeyoWPF.Service.Interfaces.Auth;

namespace ZeeyoWPF.UI.Windows
{
    public partial class ForgetPasswordWindow : Window
    {
        private readonly HttpClient _httpClient;
        private readonly IEmailService _emailService;
        public ForgetPasswordWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _emailService = new EmailService();
        }
        private async void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            var data = phoneNumberOrEmailTextBox.Text;

            var result = await _emailService.SendCodeByEmailAsync(data);

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
