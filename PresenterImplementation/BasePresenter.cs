using PresenterAbstraction;
using ViewAbstraction;

namespace PresenterImplementation
{
    public abstract class BasePresenter : IPresenter
    {
        protected readonly IViewContainer _viewContainer;
        public abstract void Init();

        public BasePresenter(IViewContainer viewContainer)
        {
            _viewContainer = viewContainer;
        }

        public void Initialize()
        {
            Init();
        }
    }
}
