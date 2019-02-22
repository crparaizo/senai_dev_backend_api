using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Domains.Enums;
using Senai.Svigufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class ConviteRepository : IConviteRepository
    {
        private string StringConexao = @"Data Source =.\SqlExpress;initial catalog=SENAI_SVIGUFU_TARDE;user id=sa;password=132";

        public void Cadastrar(ConviteDomain convite)
        {
            string QueryInsert = @"insert into CONVITES (ID_EVENTO, ID_USUARIO, SITUACAO) VALUES(15, 3, 1)";

            using (SqlConnection con = new SqlConnection (StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand (QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@ID_EVENTO", convite.EventoId);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", convite.UsuarioId);
                    cmd.Parameters.AddWithValue("@SITUACAO", convite.Situacao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ConviteDomain> Listar()
        {
            string QuerySelect = @"SELECT C.ID AS ID_CONVITE
	                ,C.SITUACAO
	                ,E.ID AS ID_EVENTO
	                ,E.TITULO AS TITULO_EVENTO
	                ,E.DATA_EVENTO AS DATA_EVENTO
	                ,U.ID AS ID_USUARIO
	                ,U.NOME AS NOME_USUARIO
	                ,U.EMAIL AS EMAIL_USUARIO
	                ,TE.ID AS ID_TIPO_EVENTO
	                ,TE.TITULO AS TITULO_TIPO_EVENTO
                    FROM
                    CONVITES C 
                    INNER JOIN EVENTOS E
                    ON C.ID_EVENTO = E.ID 
                    INNER JOIN USUARIOS U
                    ON C.ID_USUARIO = U.ID
                    INNER JOIN TIPOS_EVENTOS TE
                    ON E.ID_TIPO_EVENTO = TE.ID;";

            List<ConviteDomain> listaConvites = new List<ConviteDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ConviteDomain convite = new ConviteDomain
                        {
                            Id = Convert.ToInt32(sdr["ID_CONVITE"]),
                            Situacao = (EnSituacaoConvite)Convert.ToInt32(sdr["SITUACAO"]),
                            Usuario = new UsuarioDomain
                            {
                                //ID_USUARIO, NOME_USUARIO, EMAIL_USUARIO
                                Id = Convert.ToInt32(sdr["ID_USUARIO"]),
                                Nome = sdr["NOME_USUARIO"].ToString(),
                                Email = sdr["EMAIL_USUARIO"].ToString()
                            },
                            Evento = new EventoDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_EVENTO"]),
                                Titulo = sdr["TITULO_EVENTO"].ToString(),
                                DataEvento = Convert.ToDateTime(sdr["DATA_EVENTO"]),
                                TipoEvento = new TipoEventoDomain
                                {
                                    Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                    Nome = sdr["TITULO_TIPO_EVENTO"].ToString()
                                }
                            }
                        };
                        listaConvites.Add(convite);

                    }
                    return listaConvites;
                }
            }
        }

        public List<ConviteDomain> ListarMeusConvites(int usuarioId)
        {
            string QuerySelect = @"SELECT C.ID AS ID_CONVITE
	                ,C.SITUACAO
	                ,E.ID AS ID_EVENTO
	                ,E.TITULO AS TITULO_EVENTO
	                ,E.DATA_EVENTO AS DATA_EVENTO
	                ,U.ID AS ID_USUARIO
	                ,U.NOME AS NOME_USUARIO
	                ,U.EMAIL AS EMAIL_USUARIO
	                ,TE.ID AS ID_TIPO_EVENTO
	                ,TE.TITULO AS TITULO_TIPO_EVENTO
                    FROM
                    CONVITES C 
                    INNER JOIN EVENTOS E
                    ON C.ID_EVENTO = E.ID 
                    INNER JOIN USUARIOS U
                    ON C.ID_USUARIO = U.ID
                    INNER JOIN TIPOS_EVENTOS TE
                    ON E.ID_TIPO_EVENTO = TE.ID
                    WHERE ID_USUARIO = @ID_USUARIO;";

            List<ConviteDomain> listaConvites = new List<ConviteDomain>();


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("ID_USUARIO", usuarioId);

                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ConviteDomain convite = new ConviteDomain
                        {
                            Id = Convert.ToInt32(sdr["ID_CONVITE"]),
                            Situacao = (EnSituacaoConvite)Convert.ToInt32(sdr["SITUACAO"]),
                            Usuario = new UsuarioDomain
                            {
                                //ID_USUARIO, NOME_USUARIO, EMAIL_USUARIO
                                Id = Convert.ToInt32(sdr["ID_USUARIO"]),
                                Nome = sdr["NOME_USUARIO"].ToString(),
                                Email = sdr["EMAIL_USUARIO"].ToString()
                            },
                            Evento = new EventoDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_EVENTO"]),
                                Titulo = sdr["TITULO_EVENTO"].ToString(),
                                DataEvento = Convert.ToDateTime(sdr["DATA_EVENTO"]),
                                TipoEvento = new TipoEventoDomain
                                {
                                    Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                    Nome = sdr["TITULO_TIPO_EVENTO"].ToString()
                                }
                            }
                        };
                        listaConvites.Add(convite);

                    }
                    return listaConvites;
                }
            }
        }
    }
}