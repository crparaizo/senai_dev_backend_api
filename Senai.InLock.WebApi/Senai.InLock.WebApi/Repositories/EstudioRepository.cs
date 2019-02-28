using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = @"Data Source =.\SqlExpress;initial catalog=InLock_Games_Tarde;user id=sa;password=132";

        public List<EstudioDomain> Listar()
        {

            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = @"SELECT * FROM Estudios";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                            NomeEstudio = sdr["NomeEstudio"].ToString(),
                        };

                        listaEstudios.Add(estudio);
                    }
                return listaEstudios;
                }
            }
        }
    }
}