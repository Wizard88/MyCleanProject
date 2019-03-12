using ViewModel;

namespace ViewAbstraction
{
    public interface IStudentView
    {
        void RegisterModel(StudentViewModel model);
        void RegisterInitModel(StudentInitModel model);

        event ButtonDelegate AcceptAction;
        event ButtonDelegate DeclineAction;
    }
}
