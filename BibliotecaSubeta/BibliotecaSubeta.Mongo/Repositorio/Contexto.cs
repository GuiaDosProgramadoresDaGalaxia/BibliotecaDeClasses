using BibliotecaSubeta.Mongo.Entidades;
using MongoDB.Driver;
using System;
using System.Configuration;

namespace BibliotecaSubeta.Mongo.Repositorio
{
    public class Contexto : IContexto
    {
        private readonly IMongoDatabase database;

        public IMongoDatabase DataBase { get { return database; } }

        public Contexto(string connectionStringNameAppConfig)
        {
            var cliente = new MongoClient(ConfigurationManager.ConnectionStrings[connectionStringNameAppConfig].ConnectionString);
            database = cliente.GetDatabase("GerenciadorMongo");
        }

        public IMongoCollection<TEntidade> Set<TEntidade>() where TEntidade : class, IEntidade, new()
        {
            var entidadeTipo = typeof(TEntidade);
            var atributo = Attribute.GetCustomAttribute(entidadeTipo, typeof(ColecaoAttribute));
            var colecao = atributo as ColecaoAttribute;

            return database.GetCollection<TEntidade>(colecao.Nome);
        }
    }
}
