using BibliotecaSubeta.Dominio;

namespace BibliotecaSubeta.MVVM.Dialogs
{
    public class CancelarViewModelDialog : ViewModelDialog<CancelarModel>
    {
        public CancelarViewModelDialog(string hint, IRepositorio repositorio) : base(hint, repositorio)
        {
        }
    }
}
