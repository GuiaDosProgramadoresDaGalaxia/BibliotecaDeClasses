using BibliotecaSubeta.Dominio;

namespace BibliotecaSubeta.MVVM
{
    public abstract class ViewModelDialog<TModel> : ViewModelBase, IViewModelDialog where TModel : Model, new()
    {
        public TModel Model { get; set; }
        public string Hint { get; set; }

        /// <summary>
        /// Uso do Hint: "{Binding Hint}"
        /// </summary>
        /// <param name="hint">Mensagem a ser colocada na WaterMark do dialog.</param>
        /// <param name="repositorio"></param>
        public ViewModelDialog(string hint, IRepositorio repositorio) : base(repositorio)
        {
            Model = new TModel();
            Hint = hint;
        }
    }
}
