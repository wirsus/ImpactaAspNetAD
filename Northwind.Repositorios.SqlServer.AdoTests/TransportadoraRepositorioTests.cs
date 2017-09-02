using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Dominio;
using Northwind.Repositorios.SqlServer.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class TransportadoraRepositorioTests
    {
        TransportadoraRepositorio _repositorio = new TransportadoraRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {
            Assert.IsTrue(_repositorio.Selecionar().Any());
        }

        [TestMethod()]
        public void SelecionarComIdTest()
        {
            Assert.IsNotNull(_repositorio.Selecionar(1));
            Assert.IsNull(_repositorio.Selecionar(4561));
        }

        [TestMethod()]
        public void InserirTest()
        {
            var transportadora = new Transportadora();
            transportadora.Nome = "Teste Transportes";
            transportadora.Telefone = "(111) 111-1111";

            _repositorio.Inserir(transportadora);

            Assert.AreNotEqual(0, transportadora.ID);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var transportadora = new Transportadora();
            transportadora.ID = 6;
            transportadora.Nome = "Teste Atualizado";
            transportadora.Telefone = "(222) 222-2222";

            _repositorio.Atualizar(transportadora);

            Assert.AreEqual(_repositorio.Selecionar(transportadora.ID).Nome, transportadora.Nome);
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _repositorio.Excluir(6);

            Assert.IsNull(_repositorio.Selecionar(6));
        }
    }
}
