using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace BibliotecaSubeta.MVVM.Uteis
{
    /// <summary>
    /// Implementação basica da interface IMessageService com mensagens padrões
    /// </summary>
    public class MessageService : IMessageService
    {
        protected readonly SnackbarMessageQueue messageQueue;
        public SnackbarMessageQueue MessageQueue { get { return messageQueue; } }

        public MessageService(SnackbarMessageQueue _messageQueue)
        {
            messageQueue = _messageQueue;
        }

        public void Adicionado()
        {
            Task.Factory.StartNew(() => messageQueue.Enqueue("O item foi adicionado com sucesso!"));
        }

        public void AdicionarErro()
        {
            Task.Factory.StartNew(() => messageQueue.Enqueue("O item não pode ser adicionado, pois contem dependencias!"));
        }

        public void Deletado()
        {
            Task.Factory.StartNew(() => messageQueue.Enqueue("O item foi deletado com sucesso!"));
        }

        public void DeletarErro()
        {
            Task.Factory.StartNew(() => messageQueue.Enqueue("O item não pode ser deletado, pois contem dependencias!"));
        }

        public void Editado()
        {
            Task.Factory.StartNew(() => messageQueue.Enqueue("O item foi editado com sucesso!"));
        }

        public void EditarErro()
        {
            Task.Factory.StartNew(() => messageQueue.Enqueue("O item não pode ser editado, pois contem dependencias!"));
        }

        public void Mensagem(string mensagem)
        {
            Task.Factory.StartNew(() => messageQueue.Enqueue(mensagem));
        }
    }
}
