using System.ComponentModel;

namespace BibliotecaSubeta.MVVMCross.Models
{
    public abstract class Model<T> : IModel<T>
    {
        public T Id { get; set; }

        object IModel.Id { get { return this.Id; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
