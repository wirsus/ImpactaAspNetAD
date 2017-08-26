using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class ProdutoRepositorio : RepositorioDataTableBase
    {
        public DataTable SelecionarPorCategoria(int CategoriaID)
        {
            var instrucao = @"SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products WHERE ProductID = @categoriaId";

            var parametros = new List<SqlParameter>();
            parametros.Add()

            return base.Selecionar(instrucao);
        }
    }
}
