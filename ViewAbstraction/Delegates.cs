using ViewModel;

namespace ViewAbstraction
{
    public delegate void TabSelectDelegate(int index);
    public delegate void CourseDelegate(CourseViewModel item);
    public delegate void StudentDelegate(StudentViewModel item);
    public delegate void ButtonDelegate();
}
