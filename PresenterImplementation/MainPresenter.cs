using InteractorAbstraction;
using PresenterAbstraction;
using PresenterAbstraction.ResponseModel;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using ViewAbstraction;
using ViewModel;

namespace PresenterImplementation
{
    public class MainPresenter : BasePresenter, IStudentsCallback, ICoursesCallback
    {
        private readonly IMainView _mainView;
        private readonly IStudentsView _studentsView;
        private readonly ICoursesView _coursesView;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        private Action CreateAction;
        private Action UpdateAction;
        private Action DeleteAction;

        private BindingList<StudentViewModel> _listStudents;
        private BindingList<CourseViewModel> _listCourses;

        private CourseViewModel _selectedCourse;
        private StudentViewModel _selectedStudent;

        public MainPresenter(IViewContainer viewContainer, IMainView mainView, IStudentsView studentsView, ICoursesView coursesView) : base(viewContainer)
        {
            //views
            _mainView = mainView;
            _studentsView = studentsView;
            _coursesView = coursesView;

            //views models
            _listStudents = new BindingList<StudentViewModel>();
            _listCourses = new BindingList<CourseViewModel>();

            //repository
            _studentRepository = RepositoryFactory.Scope.Instance.GetStudentRepository();
            _courseRepository = RepositoryFactory.Scope.Instance.GetCourseRepository();
        }

        #region IViewContainer
        private void ViewClosedEvent(object sender, EventArgs e)
        {
        }

        private void ViewShownEvent(object sender, EventArgs e)
        {
            ReadCourses();
            ReadStudents();
        }

        private void ReadCourses()
        {
            try
            {
                InteractorFactory.Scope.Instance.GetCommandAllCourses(this, _courseRepository).Execute();
            }
            catch (CourseException courseExc)
            {
                _viewContainer.ShowError("Error", courseExc.Source);
            }
            catch (Exception exc)
            {
                _viewContainer.ShowError(exc.Message, exc.StackTrace);
            }
        }

        private void ReadStudents()
        {
            try
            {
                InteractorFactory.Scope.Instance.GetCommandAllStudents(this, _studentRepository).Execute();
            }
            catch (StudentException studentExc)
            {
                _viewContainer.ShowError(studentExc.Message, studentExc.Source);
            }
            catch (Exception exc)
            {
                _viewContainer.ShowError(exc.Message, exc.Source);
            }
        }
        #endregion

        #region Students Calback
        public void Notify(List<StudentResponse> response)
        {
            _listStudents.Clear();
            response.ForEach(x => _listStudents.Add(GetStudentViewModel(x)));
        }

        private StudentViewModel GetStudentViewModel(StudentResponse item)
        {
            return new StudentViewModel()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                Sex = item.Sex
            };
        }
        #endregion

        #region CourseCallback
        public void Notify(List<CourseResponse> response)
        {
            _listCourses.Clear();
            response.ForEach(x => _listCourses.Add(GetCourseViewModel(x)));
        }

        private CourseViewModel GetCourseViewModel(CourseResponse item)
        {
            return new CourseViewModel()
            {
                ID = item.ID,
                Name = item.Name,
                Description = item.Description
            };
        }
        #endregion

        public override void Init()
        {
            _viewContainer.ShownEvent += ViewShownEvent;
            _viewContainer.ClosedEvent += ViewClosedEvent;

            _mainView.TabSelected += MainViewTabSelected;
            _mainView.CreateAction += MainViewCreateAction;
            _mainView.UpdateAction += MainViewUpdateAction;
            _mainView.DeleteAction += MainViewDeleteAction;
            _mainView.StudentSelected += MainViewStudentSelected;
            _mainView.CourseSelected += MainViewCourseSelected;
            MainViewTabSelected(0);
            _coursesView.RegisterModel(_listCourses);
            _studentsView.RegisterModel(_listStudents);
        }

        private void MainViewCourseSelected(CourseViewModel item)
        {
            _selectedCourse = item;
        }

        private void MainViewStudentSelected(StudentViewModel item)
        {
            _selectedStudent = item;
        }

        private void MainViewDeleteAction()
        {
            DeleteAction?.Invoke();
        }

        private void MainViewUpdateAction()
        {
            UpdateAction?.Invoke();
        }

        private void MainViewCreateAction()
        {
            CreateAction?.Invoke();
        }

        private void MainViewTabSelected(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        CreateAction = CreateCourse;
                        UpdateAction = UpdateCourse;
                        DeleteAction = DeleteCourse;
                        break;
                    }
                case 1:
                    {
                        CreateAction = CreateStudent;
                        UpdateAction = UpdateStudent;
                        DeleteAction = DeleteStudent;
                        break;
                    }
                default:
                    break;
            }
        }

        private void UpdateCourse()
        {
            if (_selectedCourse != null)
            {
                IViewContainer view = ViewFactory.Scope.Instance.GetCourseView(_selectedCourse.ID);
                view.ClosedEvent += (sender, arg) => ReadCourses();
                view.ShowViewAsDialog();
            }
            else
            {
                _viewContainer.ShowWarning("Warning", "Please select some item");
            }
        }

        private void DeleteCourse()
        {
            try
            {
                InteractorFactory.Scope.Instance.GetCommandRemoveCourse(_courseRepository).Execute(_selectedCourse.ID);
                ReadCourses();
            }
            catch (Exception exc)
            {
                _viewContainer.ShowError("Error while delete course", exc.Source);
            }
        }

        private void CreateCourse()
        {
            IViewContainer view = ViewFactory.Scope.Instance.GetCourseView();
            view.ClosedEvent += (sender, arg) => ReadCourses();

            view.ShowViewAsDialog();
        }

        private void DeleteStudent()
        {
            try
            {
                InteractorFactory.Scope.Instance.GetCommandRemoveStudent(_studentRepository).Execute(_selectedStudent.ID);
                ReadStudents();
            }
            catch (Exception exc)
            {
                _viewContainer.ShowError("Error while delete student", exc.StackTrace);
            }
        }

        private void UpdateStudent()
        {
            IViewContainer view = ViewFactory.Scope.Instance.GetStudentView(_selectedStudent.ID);
            view.ClosedEvent += (sender, arg) => ReadStudents();
            view.ShowViewAsDialog();
        }

        private void CreateStudent()
        {
            IViewContainer view = ViewFactory.Scope.Instance.GetStudentView();
            view.ClosedEvent += (sender, args) => ReadStudents();

            view.ShowViewAsDialog();
        }
    }
}
