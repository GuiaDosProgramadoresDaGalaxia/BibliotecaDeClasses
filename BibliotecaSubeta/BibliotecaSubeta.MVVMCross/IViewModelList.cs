using BibliotecaSubeta.MVVMCross.Models;
using BibliotecaSubeta.MVVMCross.Uteis;
using System.Collections.ObjectModel;

namespace BibliotecaSubeta.MVVMCross
{
    public interface IViewModelList<TModel> : IViewModelBase where TModel : class, IModel
    {
        ObservableCollection<TModel> Models { get; set; }

        Command AdicionarCommand { get; set; }
        Command<TModel> EditarCommand { get; set; }
        Command<TModel> ExcluirCommand { get; set; }

        void Adicionar();
        void Editar(TModel model);
        void Excluir(TModel model);
    }
}
