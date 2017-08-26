using System.Data;
using System.Data.SqlClient;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class FornecedorRepositorio : RepositorioDataTableBase
    {
        public DataTable Selecionar()
        {
            var instrucao = @"SELECT SupplierID, CompanyName FROM Suppliers;";

            return base.Selecionar(instrucao);

            //var fornecedorDataTable = new DataTable();

            //using (var conexao = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            //{
            //    conexao.Open();

            //    var instrucao = @"SELECT SupplierID, CompanyName FROM Suppliers;";

            //    using (var comando = new SqlCommand(instrucao, conexao))
            //    {
            //        using (var dataAdapter = new SqlDataAdapter(comando))
            //        {
            //            dataAdapter.Fill(fornecedorDataTable);
            //        }
            //    }

            //    //conexao.Close();
            //}
            //return fornecedorDataTable;
        }
    }
}
