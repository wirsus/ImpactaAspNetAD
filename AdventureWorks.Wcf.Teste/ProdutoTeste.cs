using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks.Wcf.Teste.ProdutosServiceReference;
using System.Linq;

namespace AdventureWorks.Wcf.Teste
{
    [TestClass]
    public class ProdutoTeste
    {
        [TestMethod]
        public void GetTeste()
        {
            using (var cliente = new ProdutosClient())
            {
                var produto = cliente.Get(316);
                Assert.AreEqual(produto.Name, "Blade");
            }
        }

        [TestMethod]
        public void GetNameTeste()
        {
            using (var cliente = new ProdutosClient())
            {
                var produtos = cliente.GetByName("Mountain");
                Assert.IsTrue(produtos.Any());
            }
        }
    }
}
