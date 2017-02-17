using System;

namespace BibliotecaSubeta.Entity.Entidades
{
    public interface IEntidade
    {
        object Id { get; }
        bool Ativo { get; set; }
        DateTime DataCriacao { get; set; }
        DateTime? DataModificacao { get; set; }
        string CriadoPor { get; set; }
        string ModificadoPor { get; set; }
    }

    public interface IEntidade<T> : IEntidade
    {
        new T Id { get; set; }
    }
}
