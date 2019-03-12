namespace ViewModel
{
    public class ComboBoxItem<T>
    {
        private readonly string _view;
        private readonly T _value;

        public ComboBoxItem(string view, T value)
        {
            _view = view;
            _value = value;
        }

        public string View => _view;

        public T Value => _value;
    }
}