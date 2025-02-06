using ZeeyoWPF.Service.ViewModels.Commons;
using ZeeyoWPF.Service.Models.StudentModels;

namespace ZeeyoWPF.Service.ViewModels.Students;

public class StudentViewModel : BaseViewModel
{
    private StudentForCreationDto _student;

    public StudentViewModel()
    {
        _student = new StudentForCreationDto
        {
            FirstName = "Muhammadzokir",
            LastName = "Alijonov",
            PhoneNumber = "+998945080030",
        };
    }

    public string FirstName
    {
        get => _student.FirstName;
        set
        {
            if (_student.FirstName != value)
            {
                _student.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
    }

    public string LastName
    {
        get => _student.LastName;
        set
        {
            if (_student.LastName != value)
            {
                _student.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
    }

    public string PhoneNumber
    {
        get => _student.PhoneNumber;
        set
        {
            if (_student.PhoneNumber != value)
            {
                _student.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
    }
}
