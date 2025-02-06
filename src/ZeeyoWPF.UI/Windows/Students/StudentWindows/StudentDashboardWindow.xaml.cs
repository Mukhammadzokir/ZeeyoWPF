using System.Windows;
using ZeeyoWPF.UI.Windows.Students.Views;
using ZeeyoWPF.Service.Models.StudentModels;

namespace ZeeyoWPF.UI.Windows.Students.StudentWindows;

/// <summary>
/// Interaction logic for StudentDashboardWindow.xaml
/// </summary>
public partial class StudentDashboardWindow : Window
{
    public StudentDashboardWindow()
    {
        InitializeComponent();
    }

    private void ProfileBtn_Clicked(object sender, RoutedEventArgs e)
    {
        var studentModel = new StudentForCreationDto();
        MainContent.Content = new ProfileView(studentModel);
    }
}
