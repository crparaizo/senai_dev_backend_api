using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private string StringConexao = @"Data Source =.\SqlExpress;initial catalog=SENAI_SVIGUFU_TARDE;user id=sa;password=132";

        public void Atualizar(EventoDomain evento, int id)
        {
            string QueryUpdate = @"UPDATE EVENTOS SET TITULO = @TITULO, DESCRICAO = @DESCRICAO, DATA_EVENTO = @DATA_EVENTO, ACESSO_LIVRE = @ACESSO_LIVRE , ID_TIPO_EVENTO = @ID_TIPO_EVENTO, ID_INSTITUICAO = @ID_INSTITUICAO WHERE ID = @ID";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@TITULO", evento.Titulo);
                    cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                    cmd.Parameters.AddWithValue("@DATA_EVENTO", evento.DataEvento);
                    cmd.Parameters.AddWithValue("@ACESSO_LIVRE", evento.AcessoLivre);
                    cmd.Parameters.AddWithValue("@ID_INSTITUICAO", evento.InstituicaoId);
                    cmd.Parameters.AddWithValue("@ID_TIPO_EVENTO", evento.TipoEventoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(EventoDomain evento)
        {
            string QueryInsert = @"INSERT INTO EVENTOS (TITULO, DESCRICAO, DATA_EVENTO, ACESSO_LIVRE, ID_INSTITUICAO, ID_TIPO_EVENTO)
                VALUES(@TITULO, @DESCRICAO, @DATA_EVENTO, @ACESSO_LIVRE, @ID_INSTITUICAO, @ID_TIPO_EVENTO)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@TITULO", evento.Titulo);
                    cmd.Parameters.AddWithValue("@DESCRICAO", evento.Descricao);
                    cmd.Parameters.AddWithValue("@DATA_EVENTO", evento.DataEvento);
                    cmd.Parameters.AddWithValue("@ACESSO_LIVRE", evento.AcessoLivre);
                    cmd.Parameters.AddWithValue("@ID_INSTITUICAO", evento.InstituicaoId);
                    cmd.Parameters.AddWithValue("@ID_TIPO_EVENTO", evento.TipoEventoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EventoDomain> Listar()
        {
            string QuerySelect = @"SELECT EVENTOS.ID AS ID_EVENTO,
	        EVENTOS.TITULO AS TITULO_EVENTO ,
	        EVENTOS.DESCRICAO,
	        EVENTOS.DATA_EVENTO,
	        EVENTOS.ACESSO_LIVRE,
	        TIPOS_EVENTOS.ID AS ID_TIPO_EVENTO,
	        TIPOS_EVENTOS.TITULO AS TITULO_TIPO_EVENTO,
	        INSTITUICOES.ID AS ID_INSTITUICAO,
	        INSTITUICOES.NOME_FANTASIA,
	        INSTITUICOES.RAZAO_SOCIAL,
	        INSTITUICOES.CNPJ,
	        INSTITUICOES.LOGRADOURO,
	        INSTITUICOES.CEP,
	        INSTITUICOES.UF,
	        INSTITUICOES.CIDADE

            FROM EVENTOS INNER JOIN TIPOS_EVENTOS
            ON 
            EVENTOS.ID_TIPO_EVENTO = TIPOS_EVENTOS.ID
            INNER JOIN
            INSTITUICOES
            ON
            EVENTOS.ID_INSTITUICAO = INSTITUICOES.ID";


            List<EventoDomain> listaEventos = new List<EventoDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        EventoDomain evento = new EventoDomain
                        {
                            Id = Convert.ToInt32(sdr["ID_EVENTO"]),
                            Titulo = sdr["TITULO_EVENTO"].ToString(),
                            Descricao = sdr["DESCRICAO"].ToString(),
                            DataEvento = Convert.ToDateTime(sdr["DATA_EVENTO"].ToString()),
                            AcessoLivre = Convert.ToBoolean(sdr["ACESSO_LIVRE"]),
                            TipoEvento = new TipoEventoDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                Nome = sdr["TITULO_TIPO_EVENTO"].ToString()
                            },
                            Instituicao = new InstituicaoDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_INSTITUICAO"]),
                                NomeFantasia = sdr["NOME_FANTASIA"].ToString(),
                                RazaoSocial = sdr["RAZAO_SOCIAL"].ToString(),
                                CNPJ = sdr["CNPJ"].ToString(),
                                Logradouro = sdr["LOGRADOURO"].ToString(),
                                CEP = sdr["CEP"].ToString(),
                                UF = sdr["UF"].ToString(),
                                Cidade = sdr["CIDADE"].ToString()
                            }
                        };
                    listaEventos.Add(evento);
                    }
                    return listaEventos;
                }
            }
        }
    }
}