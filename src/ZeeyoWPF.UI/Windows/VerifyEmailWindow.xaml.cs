﻿using System.Windows;
using System.Net.Http;
using ZeeyoWPF.Service.ViewModels;

namespace ZeeyoWPF.UI.Windows
{
    /// <summary>
    /// Interaction logic for VerifyEmailWindow.xaml
    /// </summary>
    public partial class VerifyEmailWindow : Window
    {
        private readonly HttpClient _httpClient;
        private readonly VerifyEmailViewModel _verifyEmailViewModel;
        public VerifyEmailWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _verifyEmailViewModel = new VerifyEmailViewModel();

            this.DataContext = _verifyEmailViewModel;
        }

        private async void VeriyfBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = await _verifyEmailViewModel.VerifyEmailCodeAsync();
            if (result == false)
            {
                MessageBox.Show(_verifyEmailViewModel.LoginMessage);
            }
            else
            {
                ResetPasswordWindow resetPasswordWindow = new ResetPasswordWindow();
                resetPasswordWindow.Show();
                this.Close();
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
}
