using System;
using ViewAbstraction;
using ViewFactory;

namespace ViewImplementation
{
    public class Factory : IFactory
    {
        public IViewContainer GetCourseView()
        {
            CourseView view = new CourseView();
            PresenterFactory.Scope.Instance.GetCourseCreatePresenter(view, view).Initialize();

            return view;
        }

        public IViewContainer GetCourseView(Guid id)
        {
            CourseView view = new CourseView();
            PresenterFactory.Scope.Instance.GetCourseUpdatePresenter(view, view, id).Initialize();

            return view;
        }

        public IViewContainer GetMainView()
        {
            MainView view = new MainView();
            PresenterFactory.Scope.Instance.GetMainPresenter(view, view, view, view).Initialize();

            return view;
        }

        public IViewContainer GetStudentView()
        {
            StudentView view = new StudentView();
            PresenterFactory.Scope.Instance.GetStudentCreatePresenter(view, view, view).Initialize();

            return view;
        }

        public IViewContainer GetStudentView(Guid id)
        {
            StudentView view = new StudentView();
            PresenterFactory.Scope.Instance.GetStudentUpdatePresenter(view, view, view, id).Initialize();

            return view;
        }
    }
}
