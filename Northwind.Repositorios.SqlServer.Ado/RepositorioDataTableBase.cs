using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class RepositorioDataTableBase
    {
        public DataTable Selecionar(string instrucao, List<SqlParameter> parametros = null)
        {
            var dataTable = new DataTable();

            //using (var conexao = new SqlConnection(@"Data Source=WIRSUS\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            using (var conexao = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            {
                conexao.Open();

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    using (var dataAdapter = new SqlDataAdapter(comando))
                    {
                        if (parametros != null)
                        {
                            dataAdapter.SelectCommand.Parameters.AddRange(parametros.ToArray());
                        }

                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}