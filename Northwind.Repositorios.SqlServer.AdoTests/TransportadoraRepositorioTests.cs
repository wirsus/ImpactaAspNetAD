using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    }
}
