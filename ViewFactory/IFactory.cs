using System;
using ViewAbstraction;

namespace ViewFactory
{
    public interface IFactory
    {
        IViewContainer GetMainView();

        IViewContainer GetStudentView();
        IViewContainer GetStudentView(Guid id);

        IViewContainer GetCourseView();
        IViewContainer GetCourseView(Guid id);
    }
}
