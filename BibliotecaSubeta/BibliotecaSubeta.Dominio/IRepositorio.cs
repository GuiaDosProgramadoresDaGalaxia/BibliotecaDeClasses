using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BibliotecaSubeta.Dominio
{
    public interface IRepositorio : IDisposable
    {
        /// <summary>
        /// Obtém uma lista de registros.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da lista</param>
        /// <param name="ordenarPor">Ordenacao</param>
        /// <param name="skip">Pular</param>
        /// <param name="take">Pegar tantos</param>
        /// <param name="incluirPropriedades">Incluir relacionamentos</param>
        /// <returns></returns>
        IEnumerable<TEntidade> ObterTodos<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém uma lista de registros assincronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da lista</param>
        /// <param name="ordenarPor">Ordenacao</param>
        /// <param name="skip">Pular</param>
        /// <param name="take">Pegar tantos</param>
        /// <param name="incluirPropriedades">Incluir relacionamentos</param>
        /// <returns></returns>
        Task<IEnumerable<TEntidade>> ObterTodosAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém um registro.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro do registro</param>
        /// <param name="incluirPropriedades">Incluir relacionamentos</param>
        /// <returns></returns>
        TEntidade Obter<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém um registro assicronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro do registro</param>
        /// <param name="incluirPropriedades">Incluir relacionamentos</param>
        /// <returns></returns>
        Task<TEntidade> ObterAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém o primeiro registro da busca.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro do registro</param>
        /// <param name="ordenarPor">Ordenacao do registro</param>
        /// <param name="incluirPropriedades">Incluir relacionamentos.</param>
        /// <returns></returns>
        TEntidade ObterPrimeiro<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém o primeiro registro da busca assincronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro do registro</param>
        /// <param name="ordenarPor">Ordenacao do registro</param>
        /// <param name="incluirPropriedades">Incluir relacionamentos.</param>
        /// <returns></returns>
        Task<TEntidade> ObterPrimeiroAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém um registro atraves do seu Id.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="id">Id do registro</param>
        /// <returns></returns>
        TEntidade ObterPorId<TEntidade>(object id)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém um registro atraves do seu Id assicronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="id">Id do registro</param>
        /// <returns></returns>
        Task<TEntidade> ObterPorIdAsync<TEntidade>(object id)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém a quantidade de registros.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da contagem</param>
        /// <returns></returns>
        int ObterQuantidade<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Obtém a quantidade de registros assicronamente.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da contagem</param>
        /// <returns></returns>
        Task<int> ObterQuantidadeAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Verifica se existe no registro. Retorna true ou false.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da busca</param>
        /// <returns></returns>
        bool ObterExistente<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade;


        /// <summary>
        /// Verifica se existe no registro assicronamente. Retorna true ou false.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="filtro">Filtro da busca</param>
        /// <returns></returns>
        Task<bool> ObterExistenteAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Cria um registro.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <param name="criadoPor">Quem criou a entidade</param>
        void Criar<TEntidade>(TEntidade entidade, string criadoPor = null)
        where TEntidade : class, IEntidade;

        /// <summary>
        /// Atualiza uma entidade do registro.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <param name="modificadoPor">Quem modificou a entidade</param>
        void Atualizar<TEntidade>(TEntidade entidade, string modificadoPor = null)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Deleta um registro atravez da sua id.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="id">Id do registro</param>
        void Deletar<TEntidade>(object id)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Deleta um registro.
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entidade">Registro a ser deletado</param>
        void Deletar<TEntidade>(TEntidade entidade)
            where TEntidade : class, IEntidade;

        void Registrar<TEntidade>(TEntidade entidade)
            where TEntidade : class, IEntidade;

        /// <summary>
        /// Salva as alteraçoes.
        /// </summary>
        void Salvar();

        /// <summary>
        /// Salva as alteracoes assicronamente.
        /// </summary>
        /// <returns></returns>
        Task SalvarAsync();
    }
}
