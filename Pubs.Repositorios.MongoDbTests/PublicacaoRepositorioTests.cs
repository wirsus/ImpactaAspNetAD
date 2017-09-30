using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pubs.Dominio;
using Pubs.Repositorios.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pubs.Repositorios.MongoDb.Tests
{
    [TestClass()]
    public class PublicacaoRepositorioTests
    {
        PublicacaoRepositorio _repositorio = new PublicacaoRepositorio();

        [TestMethod()]
        public void InsertTest()
        {
            var publicacao = new Publicacao();
            publicacao.Autor = new Autor { Nome = "Carlos Drummond" };
            publicacao.Texto = "Texto de teste do Mongo";
            publicacao.Titulo = "Mongo Teste";
            publicacao.Comentarios.Add(
                new Comentario
                {
                    Autor = new Autor { Nome = "Comentarista 1" },
                    Texto = "Teste de comentários do comentarista 1"
                }
                    );
            publicacao.DataPublicacao = DateTime.Now;

            _repositorio.Inserir(publicacao);
                
        }

        [TestMethod]
        public void SelecionarTest()
        {
            var publicacoes = _repositorio.Selecionar();

            foreach (var publicacao in publicacoes)
            {
                Console.WriteLine(publicacao.Id);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            var guid = "b8f06d9d06c14f73ac69034afbdb9d57";
            var publicacao = _repositorio.Selecionar(new Guid(guid));

            publicacao.Texto = "TEXTO EDITADO";
            _repositorio.Atualizar(publicacao);
        }

        [TestMethod]
        public void ExcluirTest()
        {
            var guid = "b8f06d9d06c14f73ac69034afbdb9d57";
            _repositorio.Excluir(new Guid(guid));
        }
    }
}