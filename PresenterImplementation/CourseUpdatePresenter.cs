using InteractorAbstraction;
using InteractorAbstraction.RequestModels;
using PresenterAbstraction;
using PresenterAbstraction.ResponseModel;
using Repository;
using System;
using ViewAbstraction;
using ViewModel;

namespace PresenterImplementation
{
    internal class CourseUpdatePresenter : BasePresenter, ICourseCallback
    {
        private readonly ICourseView _courseView;
        private readonly ICourseRepository _courseRepository;
        private readonly Guid _id;
        private readonly CourseViewModel _courseViewModel;

        public CourseUpdatePresenter(IViewContainer viewContainer, ICourseView courseView, Guid id) : base(viewContainer)
        {
            _courseView = courseView;
            _id = id;

            _courseViewModel = new CourseViewModel();
            _courseRepository = RepositoryFactory.Scope.Instance.GetCourseRepository();
        }

        public override void Init()
        {
            _viewContainer.ShownEvent += ViewContainerShownEvent;
            _courseView.RegisterModel(_courseViewModel);
            _courseView.AcceptAction += AcceptChanges;
            _courseView.DeclineAction += DeclineChanges;
        }

        public void Notify(CourseResponse response)
        {
            _courseViewModel.ID = response.ID;
            _courseViewModel.Name = response.Name;
            _courseViewModel.Description = response.Description;
        }

        private void ViewContainerShownEvent(object sender, EventArgs e)
        {
            try
            {
                InteractorFactory.Scope.Instance.GetCommandCourseByID(this, _courseRepository).Execute(_id);
            }
            catch (CourseException exc)
            {
                _viewContainer.ShowError("Error while reading course!", exc.Source);
            }
        }

        private void DeclineChanges()
        {
            _viewContainer.CloseView();
        }

        private void AcceptChanges()
        {
            CourseRequest request = new CourseRequest()
            {
                ID = _courseViewModel.ID,
                Name = _courseViewModel.Name,
                Description = _courseViewModel.Description
            };

            try
            {
                InteractorFactory.Scope.Instance.GetCommandUpdateCourse(_courseRepository).Execute(request);
                _viewContainer.CloseView();
            }
            catch (CourseException)
            {
                _viewContainer.ShowError("Error", "Error while create course!");
            }
        }
    }
}