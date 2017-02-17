using BibliotecaSubeta.MVVMCross.Models;

namespace BibliotecaSubeta.MVVMCross
{
    public interface IViewModelPrint<TModel> : IViewModelBase where TModel : class, IModel
    {
        TModel Model { get; set; }

        void PrepararImpressao();
        void Imprimir();
    }
}
