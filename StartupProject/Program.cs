using System;
using System.Windows.Forms;
using ViewAbstraction;

namespace StartupProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //init component
            ViewFactory.Scope.Instance = new ViewImplementation.Factory();
            PresenterFactory.Scope.Instance = new PresenterImplementation.Factory();
            InteractorFactory.Scope.Instance = new InteractorImplementation.Factory();
            RepositoryFactory.Scope.Instance = new RepositoryImplementation.Factory();

            IViewContainer mainView = ViewFactory.Scope.Instance.GetMainView();
            Application.Run(mainView as Form);
        }
    }
}
