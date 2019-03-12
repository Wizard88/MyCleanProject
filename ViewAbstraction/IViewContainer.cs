using System;

namespace ViewAbstraction
{
    public interface IViewContainer
    {
        void ShowView();
        void ShowViewAsDialog();
        void CloseView();

        event EventHandler ShownEvent;
        event EventHandler ClosedEvent;

        void ShowError(string caption, string message);
        void ShowWarning(string caption, string message);
        void ShowInfo(string caption, string message);
    }
}
