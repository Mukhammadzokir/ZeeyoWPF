using System.Windows;
using System.Net.Http;
using System.Windows.Controls;
using ZeeyoWPF.Service.ViewModels;
using ZeeyoWPF.Service.Services.Auth;
using ZeeyoWPF.Service.Interfaces.Auth;

namespace ZeeyoWPF.UI.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;
        private readonly LoginViewModel _loginViewModel;
        public LoginWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _authService = new AuthService();
            _loginViewModel = new LoginViewModel();

            this.DataContext = _loginViewModel;
        }

        private void _frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = await _loginViewModel.LoginAsync();
            if (result)
            {
                MessageBox.Show(_loginViewModel.LoginMessage);
            }

        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
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
