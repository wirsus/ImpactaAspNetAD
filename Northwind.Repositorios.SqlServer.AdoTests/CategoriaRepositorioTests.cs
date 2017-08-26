using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;


namespace Northwind.Repositorios.SqlServer.Ado.Tests
{
    [TestClass()]
    public class CategoriaRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTest()
        {
            var categoriaRepositorio = new CategoriaRepositorio();

            var categoriasDataTable = categoriaRepositorio.Selecionar();

            Assert.AreNotEqual(categoriasDataTable.Rows.Count, 0);

            Console.WriteLine(categoriasDataTable.Rows[0][1]);

            foreach (DataRow registro in categoriasDataTable.Rows)
            {
                Console.WriteLine($"{registro[0]} - {registro[1]}");
            }
            

        }
    }
}