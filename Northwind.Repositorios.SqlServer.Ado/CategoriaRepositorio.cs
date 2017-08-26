using System.Data;
using System.Data.SqlClient;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class CategoriaRepositorio
    {
        public DataTable Selecionar()
        {
            var categoriaDataTable = new DataTable();

            using (var conexao = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            {
                conexao.Open();

                var instrucao = @"SELECT CategoryID, CategoryName FROM Categories;";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(categoriaDataTable);
                    }
                }

                //conexao.Close();
            }
            return categoriaDataTable;
        }
    }
}
