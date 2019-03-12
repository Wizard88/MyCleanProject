using System.ComponentModel;
using ViewModel;

namespace ViewAbstraction
{
    public interface ICoursesView
    {
        void RegisterModel(BindingList<CourseViewModel> list);
    }
}
