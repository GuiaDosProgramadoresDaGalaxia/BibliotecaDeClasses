using BibliotecaSubeta.Dominio;

namespace BibliotecaSubeta.MVVM.Dialogs
{
    public class AlertViewModelDialog : ViewModelDialog<AlertModel>
    {
        public AlertViewModelDialog(string hint, IRepositorio repositorio) : base(hint, repositorio)
        {
        }
    }
}
