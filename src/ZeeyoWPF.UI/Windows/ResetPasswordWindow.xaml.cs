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
        this.Close(); ;
    }
    private void ReturnBackBtnClick(object sender, RoutedEventArgs e)
    {
        ForgetPasswordWindow forgetPasswordWindow = new ForgetPasswordWindow();
        forgetPasswordWindow.Show();
        this.Close();
    }
}
