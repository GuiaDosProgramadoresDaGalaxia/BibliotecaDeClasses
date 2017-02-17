namespace BibliotecaSubeta.MVVMCross.Serviços
{
    public interface IDataService<TRepositorio> where TRepositorio : class
    {
        TRepositorio ObterRepositorio();
    }
}
