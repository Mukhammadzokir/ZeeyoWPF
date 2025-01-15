using System.Windows;
using System.Net.Http;
using ZeeyoWPF.Service.Services.Auth;
using ZeeyoWPF.Service.Interfaces.Auth;
using ZeeyoWPF.Service.Models.LoginModels;

namespace ZeeyoWPF.UI.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;
        public LoginWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _authService = new AuthService();
        }

        private void _frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = phoneNumberTextBox.Text;
            string password = passwordBox.Password;

            var loginModel = new LoginModel()
            {
                PhoneNumber = phoneNumber,
                Password = password
            };

            var result = await _authService.LoginAsync(loginModel);

        }


        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            // Show the password as plain text
            passwordTextBox.Text = passwordBox.Password;
            passwordBox.Visibility = Visibility.Collapsed;
            passwordTextBox.Visibility = Visibility.Visible;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            // Hide the password and use PasswordBox again
            passwordBox.Password = passwordTextBox.Text;
            passwordTextBox.Visibility = Visibility.Collapsed;
            passwordBox.Visibility = Visibility.Visible;
        }

        private void forgerPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ForgetPasswordWindow forgetPasswordWindow = new ForgetPasswordWindow();
            forgetPasswordWindow.Show();
            this.Close();
        }
    }
}
