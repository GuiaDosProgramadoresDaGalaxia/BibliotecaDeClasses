namespace BibliotecaSubeta.MVVMCross.Serviços
{
    public interface IViewServiceBase
    {
        void RegistrarView<TView, TViewModel>() where TView : class where TViewModel : class, IViewModelBase;
        void ObterView<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModelBase;
    }
}
