using MaterialDesignThemes.Wpf;

namespace BibliotecaSubeta.MVVM.Uteis
{
    public interface IMessageService
    {
        /// <summary>
        /// SnackBarQueue da biblioteca MaterialDesingThemes
        /// </summary>
        SnackbarMessageQueue MessageQueue { get; }

        void Mensagem(string mensagem);
        void Adicionado();
        void AdicionarErro();
        void Editado();
        void EditarErro();
        void Deletado();
        void DeletarErro();
    }
}
