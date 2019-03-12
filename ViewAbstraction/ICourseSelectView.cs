using System.ComponentModel;
using ViewModel;

namespace ViewAbstraction
{
    public interface ICourseSelectView
    {
        void RegisterModel(BindingList<CourseSelectViewModel> list);
    }
}
