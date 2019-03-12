using System.ComponentModel;
using ViewModel;

namespace ViewAbstraction
{
    public interface IStudentsView
    {
        void RegisterModel(BindingList<StudentViewModel> list);
    }
}
