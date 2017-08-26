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

            foreach (DataRow registro in categoriasDataTable.Rows)
            {
                Console.WriteLine($"{registro[0]} - {registro[1]}");
            }
            

        }
    }
}