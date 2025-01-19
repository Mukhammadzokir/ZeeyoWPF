using System.Windows;

namespace ZeeyoWPF.UI.Windows;

public partial class ResetPasswordWindow : Window
{
    public ResetPasswordWindow()
    {
        InitializeComponent();
    }

    private void ChangeBtnClick(object sender, RoutedEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close(); ;
        MessageBox.Show("Password is successfully changed");
    }
    private void ReturnBackBtnClick(object sender, RoutedEventArgs e)
    {
        VerifyEmailWindow verifyEmailWindow = new VerifyEmailWindow();
        verifyEmailWindow.Show();
        this.Close();
    }
}
