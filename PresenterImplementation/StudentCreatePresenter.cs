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
    internal class StudentCreatePresenter : BasePresenter, ICoursesCallback
    {
        private readonly ICourseSelectView _coursesSelectView;
        private readonly IStudentView _studentView;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        private readonly BindingList<CourseSelectViewModel> _listCourses;
        private readonly StudentViewModel _studentViewModel;
        private readonly StudentInitModel _studentInitModel;

        public StudentCreatePresenter(IViewContainer viewContainer, ICourseSelectView coursesView, IStudentView studentView) : base(viewContainer)
        {
            _coursesSelectView = coursesView;
            _studentView = studentView;

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

        #region Private members
        private void InitViewOptions()
        {
            _studentInitModel.ListSexOptions.Add(new ComboBoxItem<int>("Male", 1));
            _studentInitModel.ListSexOptions.Add(new ComboBoxItem<int>("Female", 2));
            _studentViewModel.Sex = 1;
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
                    ID = Guid.NewGuid(),
                    FirstName = _studentViewModel.FirstName,
                    LastName = _studentViewModel.LastName,
                    Age = Convert.ToInt16(_studentViewModel.Age),
                    Sex = _studentViewModel.Sex,
                    ListCourses = _listCourses.Where(x => x.Selected == true).Select(y => y.ID).ToList(),
                };

                InteractorFactory.Scope.Instance.GetCommandNewStudent(_studentRepository, _courseRepository).Execute(studentRequest);
                _viewContainer.CloseView();
            }
            catch (StudentException exc)
            {
                _viewContainer.ShowError("Error while create student!", exc.Source);
            }
        }

        private CourseRequest GetCourseRequest(CourseSelectViewModel item)
        {
            return new CourseRequest()
            {
                Name = item.Name,
                ID = item.ID
            };
        }

        public void Notify(List<CourseResponse> response)
        {
            _listCourses.Clear();
            response.ForEach(x => _listCourses.Add(GetCourseViewModel(x)));
        }

        private CourseSelectViewModel GetCourseViewModel(CourseResponse item)
        {
            return new CourseSelectViewModel()
            {
                ID = item.ID,
                Name = item.Name,
                Selected = false,
            };
        }

        private void ViewContainerShownEvent(object sender, System.EventArgs e)
        {
            RaedAllCourses();
        }

        private void RaedAllCourses()
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
        #endregion
    }
}