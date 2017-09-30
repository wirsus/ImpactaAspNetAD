using MongoDB.Bson;
using MongoDB.Driver;
using Pubs.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubs.Repositorios.MongoDb
{
    public class RepositorioBase<T> where T: EntidadeBase
    {
        IMongoDatabase _db;
        IMongoCollection<T> _colecao;

        public RepositorioBase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["pubsConnectionString"].ConnectionString;

            var databaseName = MongoUrl.Create(connectionString).DatabaseName;

            _db = new MongoClient(connectionString).GetDatabase(databaseName);

            _colecao = _db.GetCollection<T>(typeof(T).Name);
        }

        public void Inserir(T entidade)
        {
            _colecao.InsertOne(entidade);
        }

        public List<T> Selecionar()
        {
            return _colecao.Find(new BsonDocument()).ToList();
        }

        public T Selecionar(Guid guid)
        {
            return _colecao.Find(e => e.Id == guid).SingleOrDefault();
        }

        public void Atualizar(T entidade)
        {
            _colecao.ReplaceOne(e => e.Id == entidade.Id, entidade);
        }

        public void Excluir(Guid guid)
        {
            _colecao.DeleteOne(e => e.Id == guid);
        }
    }
}
