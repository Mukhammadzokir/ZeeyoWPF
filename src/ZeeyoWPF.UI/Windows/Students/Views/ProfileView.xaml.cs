using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ZeeyoWPF.Service.ViewModels.Students;
using ZeeyoWPF.Service.Models.StudentModels;

namespace ZeeyoWPF.UI.Windows.Students.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public ProfileView(StudentModel student)
        {
            InitializeComponent();
            this.DataContext = new StudentViewModel();
        }

        private void SetPhoto_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Open file dialog to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif" // Filters for image file types
            };

            // Show the dialog and check if the user selects a file
            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected file's path
                string filePath = openFileDialog.FileName;

                // Create a BitmapImage and set it as the source for the ProfileImage
                ProfileImage.Source = new BitmapImage(new Uri(filePath));
            }
        }
    }
}
