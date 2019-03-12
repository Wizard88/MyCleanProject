using InteractorAbstraction;
using InteractorAbstraction.RequestModels;
using Repository;
using ViewAbstraction;
using ViewModel;

namespace PresenterImplementation
{
    internal class CourseCreatePresenter : BasePresenter
    {
        private readonly ICourseView _courseView;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseViewModel _courseViewModel;

        public CourseCreatePresenter(IViewContainer viewContainer, ICourseView courseView) : base(viewContainer)
        {
            _courseView = courseView;

            _courseViewModel = new CourseViewModel();
            _courseRepository = RepositoryFactory.Scope.Instance.GetCourseRepository();
        }

        private void DeclineAction()
        {
            _viewContainer.CloseView();
        }

        private void AcceptChanges()
        {
            CourseRequest request = new CourseRequest()
            {
                Name = _courseViewModel.Name,
                Description = _courseViewModel.Description
            };

            try
            {
                InteractorFactory.Scope.Instance.GetCommandNewCourse(_courseRepository).Execute(request);
                _viewContainer.CloseView();
            }
            catch (CourseException)
            {
                _viewContainer.ShowError("Error", "Error while create course!");
            }
        }

        public override void Init()
        {
            _courseView.RegisterModel(_courseViewModel);
            _courseView.AcceptAction += AcceptChanges;
            _courseView.DeclineAction += DeclineAction;
        }
    }
}