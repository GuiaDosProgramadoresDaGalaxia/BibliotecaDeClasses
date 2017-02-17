using System;

namespace BibliotecaSubeta.MVVMCross.Serviços
{
    public interface IMessageService
    {
        void Mensagem(string mensagem);
        void Adicionado();
        void Editado();
        void Deletado();
        void Erro(Exception erro);        
    }
}
