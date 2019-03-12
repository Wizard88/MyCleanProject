using System.ComponentModel;

namespace ViewModel
{
    public class StudentInitModel : BaseViewModel
    {
        public BindingList<ComboBoxItem<int>> ListSexOptions { get; set; }

        public StudentInitModel()
        {
            ListSexOptions = new BindingList<ComboBoxItem<int>>();
        }
    }
}