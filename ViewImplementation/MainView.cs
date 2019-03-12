using System;
using System.ComponentModel;
using System.Windows.Forms;
using ViewAbstraction;
using ViewModel;

namespace ViewImplementation
{
    public partial class MainView : Form, IViewContainer, IMainView, IStudentsView, ICoursesView
    {
        public MainView()
        {
            InitializeComponent();
        }

        #region IViewContainer
        public event EventHandler ShownEvent;
        public event EventHandler ClosedEvent;

        public void ShowView()
        {
            Show();
        }

        public void ShowViewAsDialog()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            Close();
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

        #region IMainViewInput
        public event TabSelectDelegate TabSelected;
        public event CourseDelegate CourseSelected;
        public event StudentDelegate StudentSelected;
        public event ButtonDelegate CreateAction;
        public event ButtonDelegate UpdateAction;
        public event ButtonDelegate DeleteAction;
        #endregion

        #region IStudentsView
        public void RegisterModel(BindingList<StudentViewModel> list)
        {
            studentViewModelBindingSource.DataSource = list;
        }
        #endregion

        #region ICoursesView
        public void RegisterModel(BindingList<CourseViewModel> list)
        {
            courseViewModelBindingSource.DataSource = list;
        }
        #endregion

        #region EventsActions
        private void MainView_Shown(object sender, EventArgs e)
        {
            ShownEvent?.Invoke(sender, e);
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosedEvent?.Invoke(sender, e);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateAction?.Invoke();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAction?.Invoke();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAction?.Invoke();
        }

        private void dgvStudent_SelectionChanged(object sender, EventArgs e)
        {
            object selectedItem = dgvStudent.CurrentRow?.DataBoundItem;

            if (selectedItem != null)
            {
                StudentViewModel studentViewModel = selectedItem as StudentViewModel;
                StudentSelected?.Invoke(studentViewModel);
            }
        }

        private void dgvCourse_SelectionChanged(object sender, EventArgs e)
        {
            object selectedItem = dgvCourse.CurrentRow?.DataBoundItem;

            if (selectedItem != null)
            {
                CourseViewModel courseViewModel = selectedItem as CourseViewModel;
                CourseSelected?.Invoke(courseViewModel);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabSelected?.Invoke(tabControl.SelectedIndex);
        }
        #endregion
    }
}