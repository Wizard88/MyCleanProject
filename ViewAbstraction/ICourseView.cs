using ViewModel;

namespace ViewAbstraction
{
    public interface ICourseView
    {
        void RegisterModel(CourseViewModel model);
        event ButtonDelegate AcceptAction;
        event ButtonDelegate DeclineAction;
    }
}
