using BibliotecaSubeta.Dominio;

namespace BibliotecaSubeta.MVVM.Dialogs
{
    public class RemoverViewModelDialog : ViewModelDialog<RemoverModel>
    {
        public RemoverViewModelDialog(string hint, IRepositorio repositorio) : base(hint, repositorio)
        {
        }
    }
}
