using BibliotecaSubeta.MVVMCross.Serviços;
using System.ComponentModel;

namespace BibliotecaSubeta.MVVMCross
{
    public interface IViewModelBase : INotifyPropertyChanged
    {
        IDialogService DialogService { get; }
        IMessageService MessageService { get; }
        IValidationService ValidationService { get; }
        INavigationService NavigationService { get; }
    }
}
