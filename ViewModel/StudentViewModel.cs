using System;
using System.ComponentModel;

namespace ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private int _age;
        private int _sex;

        public BindingList<CourseViewModel> ListCourses { get; set; }

        public StudentViewModel()
        {
            ListCourses = new BindingList<CourseViewModel>();
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string SexString
        {
            get
            {
                if (_sex == 1)
                {
                    return "Male";
                }
                else if (_sex == 2)
                {
                    return "Female";
                }
                else
                {
                    return "";
                }
            }
        }

        public int Sex
        {
            get => _sex;
            set
            {
                if (_sex != value)
                {
                    _sex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Guid ID { get => _id; set => _id = value; }

        public Action AcceptAction;
        public Action DeclineAction;
    }
}
