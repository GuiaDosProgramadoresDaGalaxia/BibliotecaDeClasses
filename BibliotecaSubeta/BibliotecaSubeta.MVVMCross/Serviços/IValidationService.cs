using BibliotecaSubeta.MVVMCross.Models;

namespace BibliotecaSubeta.MVVMCross.Serviços
{
    public interface IValidationService
    {
        ValidationServiceResult Validate(IModel model);
        void ShowValidateDialog(ValidationServiceResult result);

        void ShowValidadeDialog(string message);
    }
}
