using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer.EF;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;

namespace Loja.Repositorios.SqlServer.EF.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private static LojaDbContext _dbContext = new LojaDbContext();

        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
            _dbContext.Database.Log = LogarQuery;
        }

        private static void LogarQuery(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void LojaDbContextTest()
        {
            //using (var dbContext = new LojaDbContext())
            //{
                var produtos = _dbContext.Produtos.ToList();
            //}
        }

        [TestMethod]
        public void InserirCategoriaTest()
        {
            //var categoria = new Categoria();
            //categoria.Nome = "Cozinha";
            //_dbContext.Categorias.Add(categoria);

            _dbContext.Categorias.Add(new Categoria { Nome = "Cozinha" });
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTest()
        {
            var produto = new Produto();
            produto.Nome = "Panela de pressão";
            produto.Categoria = _dbContext.Categorias.Single(c => c.Nome == "Cozinha");
            produto.Preco = 15.77M;
            produto.Estoque = 26;

            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTest()
        {
            var produto = new Produto();
            produto.Nome = "Barbeador";
            produto.Categoria = new Categoria { Nome = "Perfumaria" };
            produto.Preco = 78.23M;
            produto.Estoque = 5;

            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();
        }

        [TestMethod]
        public void EditarProduto()
        {
            var colher = _dbContext.Produtos.Where(p => p.Nome == "Panela de pressão").First();
            colher.Nome = "Liquidificador 110v";
            colher.Preco = 17.44M;

            _dbContext.SaveChanges();

            colher = _dbContext.Produtos.First(p => p.Id == 1);
            Assert.AreEqual(colher.Preco, 17.44M);
        }

        [TestMethod]
        public void ExcluirProduto()
        {
            var colher = _dbContext.Produtos.First(p => p.Id == 1);
            _dbContext.Produtos.Remove(colher);
            _dbContext.SaveChanges();

            Assert.IsFalse(_dbContext.Produtos.Any(p => p.Nome == "Liquidificador 110v"));
        }

        [TestMethod]
        public void ObterPrecoMedioPerfumaria()
        {
            var media = _dbContext.Produtos
                .Where(p => p.Categoria.Nome == "Perfumaria")
                .Average(p => p.Preco);

            Console.WriteLine("Valor médio é {0:C2}", media);
        }

        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            //carregamento tardio DESLIGADO - NÃO traz informações de prop dependentes
            var barbeador = _dbContext.Produtos.First(p => p.Nome == "Barbeador");
            Assert.IsNull(barbeador.Categoria);
        }

        [TestMethod]
        public void LazyLoadLigadoTeste()
        {
            //carregamento tardio LIGADO - TRAZ informações de prop dependentes
            var barbeador = _dbContext.Produtos.First(p => p.Nome == "Barbeador");
            Assert.IsTrue(barbeador.Categoria.Nome == "Perfumaria");
        }


        [TestMethod]
        public void IncludeTest()
        {
            var barbeador = _dbContext.Produtos
                .Include(p => p.Categoria)
                .First(p => p.Nome == "Barbeador");
        }

        [TestMethod]
        public void QueryableTeste()
        {
            var query = _dbContext.Produtos.Where(p => p.Preco > 10);
            query.OrderBy(p => p.Preco);

            var primeiro = query.First();
            var ultimo = query.Last();
            var unico = query.Single();
            
        }


        [ClassCleanup]
        public static void DescartarContexto()
        {
            _dbContext.Dispose();
        }
    }
}