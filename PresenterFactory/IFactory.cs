using PresenterAbstraction;
using System;
using ViewAbstraction;

namespace PresenterFactory
{
    public interface IFactory
    {
        IPresenter GetMainPresenter(IViewContainer viewContainer, IMainView mainView, IStudentsView studentsView, ICoursesView coursesView);
        IPresenter GetStudentCreatePresenter(IViewContainer viewContainer, ICourseSelectView courseSelectView, IStudentView studentView);
        IPresenter GetCourseCreatePresenter(IViewContainer viewContainer, ICourseView courseView);
        IPresenter GetCourseUpdatePresenter(IViewContainer viewContainer, ICourseView courseView, Guid id);
        IPresenter GetStudentUpdatePresenter(IViewContainer viewContainer, ICourseSelectView courseSelectView, IStudentView studentView, Guid id);
    }
}
