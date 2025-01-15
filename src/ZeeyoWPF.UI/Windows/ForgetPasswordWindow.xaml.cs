using System.Windows;

namespace ZeeyoWPF.UI.Windows
{
    public partial class ForgetPasswordWindow : Window
    {
        public ForgetPasswordWindow()
        {
            InitializeComponent();
        }
        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ResetPasswordWindow resetPasswordWindow = new ResetPasswordWindow();
            resetPasswordWindow.Show();
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
