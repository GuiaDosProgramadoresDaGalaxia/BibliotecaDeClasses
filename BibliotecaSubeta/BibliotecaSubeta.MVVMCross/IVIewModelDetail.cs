using BibliotecaSubeta.MVVMCross.Models;
using BibliotecaSubeta.MVVMCross.Uteis;

namespace BibliotecaSubeta.MVVMCross
{
    public interface IVIewModelDetail<TModel> : IViewModelBase where TModel : class, IModel
    {
        TModel Model { get; set; }
        DetailType Tipo { get; set; }

        Command DefaultCommand { get; set; }
        Command CancelCommand { get; set; }

        void Salvar();
        void Cancelar();
    }
}
