using InteractorAbstraction;
using InteractorAbstraction.RequestModels;
using PresenterAbstraction;
using PresenterAbstraction.ResponseModel;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ViewAbstraction;
using ViewModel;

namespace PresenterImplementation
{
    internal class StudentUpdatePresenter : BasePresenter, ICoursesCallback, IStudentCallback
    {
        private readonly ICourseSelectView _coursesSelectView;
        private readonly IStudentView _studentView;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        private readonly BindingList<CourseSelectViewModel> _listCourses;
        private readonly StudentViewModel _studentViewModel;
        private readonly StudentInitModel _studentInitModel;
        private Guid _id;

        public StudentUpdatePresenter(IViewContainer viewContainer, ICourseSelectView coursesSelectView, IStudentView studentView, Guid id) : base(viewContainer)
        {
            _coursesSelectView = coursesSelectView;
            _studentView = studentView;
            _id = id;

            _listCourses = new BindingList<CourseSelectViewModel>();
            _studentViewModel = new StudentViewModel();
            _studentInitModel = new StudentInitModel();

            _courseRepository = RepositoryFactory.Scope.Instance.GetCourseRepository();
            _studentRepository = RepositoryFactory.Scope.Instance.GetStudentRepository();
        }

        public override void Init()
        {
            _viewContainer.ShownEvent += ViewContainerShownEvent;
            _coursesSelectView.RegisterModel(_listCourses);
            _studentView.RegisterModel(_studentViewModel);
            _studentView.RegisterInitModel(_studentInitModel);

            _studentViewModel.AcceptAction = AcceptChanges;
            _studentViewModel.DeclineAction = DeclineChanges;

            InitViewOptions();
        }

        #region ICoursesCalback
        public void Notify(List<CourseResponse> response)
        {
            _listCourses.Clear();
            response.ForEach(x => _listCourses.Add(GetCourseViewModel(x)));
        }
        #endregion

        #region Private members
        private CourseSelectViewModel GetCourseViewModel(CourseResponse item)
        {
            return new CourseSelectViewModel()
            {
                ID = item.ID,
                Name = item.Name,
                Selected = false
            };
        }

        private void ViewContainerShownEvent(object sender, System.EventArgs e)
        {
            ReadAllCourses();
            ReadSelectedStudent();
        }

        private void InitViewOptions()
        {
            _studentInitModel.ListSexOptions.Add(new ComboBoxItem<int>("Male", 1));
            _studentInitModel.ListSexOptions.Add(new ComboBoxItem<int>("Female", 2));
        }

        private void DeclineChanges()
        {
            _viewContainer.CloseView();
        }

        private void AcceptChanges()
        {
            try
            {
                StudentRequest studentRequest = new StudentRequest()
                {
                    ID = _studentViewModel.ID,
                    FirstName = _studentViewModel.FirstName,
                    LastName = _studentViewModel.LastName,
                    Age = _studentViewModel.Age,
                    Sex = _studentViewModel.Sex,
                    ListCourses = _listCourses.Where(x => x.Selected == true).Select(y => y.ID).ToList(),
                };

                InteractorFactory.Scope.Instance.GetCommandUpdateStudent(_studentRepository, _courseRepository).Execute(studentRequest);
                _viewContainer.CloseView();
            }
            catch (StudentException exc)
            {
                _viewContainer.ShowError("Error while create student!", exc.Source);
            }

        }

        private void ReadSelectedStudent()
        {
            try
            {
                InteractorFactory.Scope.Instance.GetCommandStudentByID(this, _studentRepository).Execute(_id);
            }
            catch (StudentException exc)
            {
                _viewContainer.ShowError("Error reading student!", exc.StackTrace);
            }
        }

        private void ReadAllCourses()
        {
            try
            {
                InteractorFactory.Scope.Instance.GetCommandAllCourses(this, _courseRepository).Execute();
            }
            catch (CourseException exc)
            {
                _viewContainer.ShowError("Error reading courses!", exc.Source);
            }
        }

        public void Notify(StudentResponse response)
        {
            _studentViewModel.FirstName = response.FirstName;
            _studentViewModel.LastName = response.LastName;
            _studentViewModel.Age = response.Age;
            _studentViewModel.Sex = response.Sex;
            response.ListCourses.ForEach(x => CheckIsIncludedForStudent(x));
        }

        private void CheckIsIncludedForStudent(Guid id)
        {
            _listCourses.First(x => x.ID == id).Selected = true;
        }

        #endregion
    }
}
