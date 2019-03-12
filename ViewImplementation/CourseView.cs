using System;
using System.Windows.Forms;
using ViewAbstraction;
using ViewModel;

namespace ViewImplementation
{
    public partial class CourseView : Form, IViewContainer, ICourseView
    {
        public CourseView()
        {
            InitializeComponent();
        }

        #region IViewContainer
        public event EventHandler ShownEvent;
        public event EventHandler ClosedEvent;

        public void CloseView()
        {
            Close();
        }

        public void ShowError(string caption, string message)
        {
            MessageBox.Show(caption, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowWarning(string caption, string message)
        {
            MessageBox.Show(caption, message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowInfo(string caption, string message)
        {
            MessageBox.Show(caption, message, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowView()
        {
            Show();
        }

        public void ShowViewAsDialog()
        {
            ShowDialog();
        }
        #endregion

        #region ICourseView
        public void RegisterModel(CourseViewModel model)
        {
            tbName.DataBindings.Add("Text", model, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            tbDescription.DataBindings.Add("Text", model, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public event ButtonDelegate AcceptAction;
        public event ButtonDelegate DeclineAction;
        #endregion

        #region Events
        private void CourseView_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosedEvent?.Invoke(sender, e);
        }

        private void CourseView_Shown(object sender, EventArgs e)
        {
            ShownEvent?.Invoke(sender, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AcceptAction?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DeclineAction?.Invoke();
        }
        #endregion
    }
}
