using System;
using System.ComponentModel;
using System.Windows.Forms;
using ViewAbstraction;
using ViewModel;

namespace ViewImplementation
{
    public partial class StudentView : Form, IViewContainer, ICourseSelectView, IStudentView
    {
        public StudentView()
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

        public void ShowView()
        {
            Show();
        }

        public void ShowViewAsDialog()
        {
            ShowDialog();
        }

        public void ShowError(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowWarning(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowInfo(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region IStudentView
        public event ButtonDelegate AcceptAction;
        public event ButtonDelegate DeclineAction;

        public void RegisterModel(StudentViewModel model)
        {
            tbFirstName.DataBindings.Add("Text", model, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
            tbLastName.DataBindings.Add("Text", model, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
            neAge.DataBindings.Add("Value", model, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cbSex.DataBindings.Add("SelectedValue", model, "Sex", true, DataSourceUpdateMode.OnPropertyChanged);

            btnOK.Click += (sender, arg) => model.AcceptAction?.Invoke();
            btnCancel.Click += (sender, arg) => model.DeclineAction?.Invoke();
        }

        public void RegisterInitModel(StudentInitModel model)
        {
            cbSex.DataSource = model.ListSexOptions;
            cbSex.ValueMember = "Value";
            cbSex.DisplayMember = "View";
        }
        #endregion

        #region ICoursesView
        public void RegisterModel(BindingList<CourseSelectViewModel> list)
        {
            courseSelectViewModelBindingSource.DataSource = list;
        }
        #endregion

        #region Events
        private void StudentView_Shown(object sender, EventArgs e)
        {
            ShownEvent?.Invoke(sender, e);
        }

        private void StudentView_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosedEvent?.Invoke(sender, e);
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
