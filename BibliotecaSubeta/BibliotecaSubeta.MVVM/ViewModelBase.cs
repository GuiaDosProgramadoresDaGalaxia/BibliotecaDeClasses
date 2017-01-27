using BibliotecaSubeta.Dominio;
using BibliotecaSubeta.MVVM.Uteis;
using System.ComponentModel;

namespace BibliotecaSubeta.MVVM
{
    /// <summary>
    /// Classe que define os comportamentos basicos das view models: notificação, mensagens e repositorio.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly IRepositorio repositorio;
        protected readonly IMessageService messageService;

        public ViewModelBase(IRepositorio _repositorio)
        {
            repositorio = _repositorio;
            messageService = DependecyService.ObterDependencias<IMessageService>();
        }

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
