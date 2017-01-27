using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaSubeta.Dominio
{
    public abstract class Entidade<T> : IEntidade<T>
    {
        public bool Ativo { get; set; }
        public string CriadoPor { get; set; }
        public string ModificadoPor { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntidade.Id
        {
            get
            {
                return this.Id;
            }
        }

        private DateTime? dataCriacao;
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao
        {
            get { return dataCriacao ?? DateTime.UtcNow; }
            set { dataCriacao = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? DataModificacao { get; set; }

        public Entidade()
        {
            Ativo = true;
        }
    }
}
