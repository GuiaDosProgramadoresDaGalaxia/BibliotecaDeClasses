using System.ComponentModel;

namespace BibliotecaSubeta.MVVMCross.Models
{
    public interface IModel : INotifyPropertyChanged
    {
        object Id { get; }
    }

    public interface IModel<T> : IModel
    {
        new T Id { get; set; }
    }
}
