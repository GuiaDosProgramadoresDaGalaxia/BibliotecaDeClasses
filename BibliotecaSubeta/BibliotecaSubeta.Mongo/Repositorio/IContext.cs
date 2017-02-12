using BibliotecaSubeta.Mongo.Entidades;
using MongoDB.Driver;

namespace BibliotecaSubeta.Mongo.Repositorio
{
    public interface IContexto
    {
        IMongoDatabase DataBase { get; }
        IMongoCollection<TEntidade> Set<TEntidade>() where TEntidade : class, IEntidade, new();
    }
}
