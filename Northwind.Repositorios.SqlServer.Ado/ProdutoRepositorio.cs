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
        public DataTable SelecionarPorCategoria(int categoriaID)
        {
            var instrucao = @"SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products WHERE CategoryID = @categoriaId";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@categoriaId", categoriaID));

            return base.Selecionar(instrucao, parametros);
        }

        public DataTable SelecionarPorFornecedor(int fornecedorID)
        {
            var instrucao = @"SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products WHERE SupplierID = @fornecedorId";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@fornecedorId", fornecedorID));

            return base.Selecionar(instrucao, parametros);
        }
    }
}
