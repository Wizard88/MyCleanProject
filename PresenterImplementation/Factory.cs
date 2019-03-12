using PresenterAbstraction;
using PresenterFactory;
using System;
using ViewAbstraction;

namespace PresenterImplementation
{
    public class Factory : IFactory
    {
        public IPresenter GetStudentCreatePresenter(IViewContainer viewContainer, ICourseSelectView courseSelectView, IStudentView studentView)
        {
            return new StudentCreatePresenter(viewContainer, courseSelectView, studentView);
        }

        public IPresenter GetMainPresenter(IViewContainer viewContainer, IMainView mainView, IStudentsView studentsView, ICoursesView coursesView)
        {
            return new MainPresenter(viewContainer, mainView, studentsView, coursesView);
        }

        public IPresenter GetCourseCreatePresenter(IViewContainer viewContainer, ICourseView courseView)
        {
            return new CourseCreatePresenter(viewContainer, courseView);
        }

        public IPresenter GetCourseUpdatePresenter(IViewContainer viewContainer, ICourseView courseView, Guid id)
        {
            return new CourseUpdatePresenter(viewContainer, courseView, id);
        }

        public IPresenter GetStudentUpdatePresenter(IViewContainer viewContainer, ICourseSelectView courseSelectView, IStudentView studentView, Guid id)
        {
            return new StudentUpdatePresenter(viewContainer, courseSelectView, studentView, id);
        }
    }
}
