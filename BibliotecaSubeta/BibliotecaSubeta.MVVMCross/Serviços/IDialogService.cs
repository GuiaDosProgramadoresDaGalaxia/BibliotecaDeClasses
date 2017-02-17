using System.Threading.Tasks;

namespace BibliotecaSubeta.MVVMCross.Serviços
{
    public interface IDialogService
    {
        Task AlertDialog(string message);
        Task CancelDialog(string message);
        Task RemoveDialog(string message);
    }
}
