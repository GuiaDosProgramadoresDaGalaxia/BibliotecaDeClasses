using System.ComponentModel;

namespace BibliotecaSubeta.MVVM
{
    public abstract class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; set; }
        public bool Ativo { get; set; }

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public Model()
        {
            Ativo = true;
        }
    }
}
