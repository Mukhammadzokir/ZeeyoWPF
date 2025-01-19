using System.Windows;
using System.Windows.Controls;

namespace ZeeyoWPF.UI.Windows
{
    /// <summary>
    /// Interaction logic for VerifyEmailWindow.xaml
    /// </summary>
    public partial class VerifyEmailWindow : Window
    {
        public VerifyEmailWindow()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            var parent = (StackPanel)currentTextBox.Parent;
            int currentIndex = parent.Children.IndexOf(currentTextBox);

            // Check if a character has been added
            if (currentTextBox.Text.Length == 1 && currentIndex < parent.Children.Count - 1)
            {
                // Move focus to the next TextBox
                var nextTextBox = parent.Children[currentIndex + 1] as TextBox;
                nextTextBox.Focus();
            }
            else if (currentTextBox.Text.Length == 0)
            {
                // Check if backspace was pressed (removing the last character)
                var textChange = e.Changes.FirstOrDefault();
                if (textChange != null && textChange.RemovedLength > 0 && currentIndex > 0)
                {
                    // Move focus to the previous TextBox
                    var previousTextBox = parent.Children[currentIndex - 1] as TextBox;
                    previousTextBox.Focus();
                }
            }
        }

        private void VeriyfBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetPasswordWindow resetPasswordWindow = new ResetPasswordWindow();
            resetPasswordWindow.Show();
            this.Close();
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
}
