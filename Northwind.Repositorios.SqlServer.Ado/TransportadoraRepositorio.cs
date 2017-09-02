﻿using Northwind.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.SqlServer.Ado
{
    public class TransportadoraRepositorio
    {
        public List<Transportadora> Selecionar()
        {

            var transportadoras = new List<Transportadora>();

            using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            {
                conexao.Open();
                const string nomeProcedure = "TransportadoraSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            transportadoras.Add(Mapear(registro));
                        }
                    }
                }
            }

            return transportadoras;
        }

        public Transportadora Selecionar(int ID)
        {

            Transportadora transportadora = null;

            using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            {
                conexao.Open();
                const string nomeProcedure = "TransportadoraSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("ShipperID", ID);
                    //comando.Parameters.Add(new SqlParameter("ShipperID", ID));

                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.Read())
                        {
                            transportadora = Mapear(registro);
                        }
                    }
                }
            }

            return transportadora;
        }

        public void Inserir(Transportadora transportadora)
        {
            using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["northwindConnectionString"].ConnectionString))
            {
                conexao.Open();
                const string nomeProcedure = "TransportadoraInserir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(transportadora));

                    //comando.ExecuteNonQuery();
                    transportadora.ID = Convert.ToInt32(comando.ExecuteScalar());

                }
            }

        }

        private SqlParameter[] Mapear(Transportadora transportadora)
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("CompanyName", transportadora.Nome));
            parametros.Add(new SqlParameter("Phone", transportadora.Telefone ));


            return parametros.ToArray();
        }

        private Transportadora Mapear(SqlDataReader registro)
        {
            var transportadora = new Transportadora();
            transportadora.ID = Convert.ToInt32(registro["ShipperID"]);
            transportadora.Nome = registro["CompanyName"].ToString();
            transportadora.Telefone = Convert.ToString(registro["Phone"]);

            return transportadora;
        }
    }
}
