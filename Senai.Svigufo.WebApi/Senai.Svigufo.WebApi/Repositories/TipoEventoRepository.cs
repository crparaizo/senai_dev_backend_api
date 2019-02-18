using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        //Data Source - Nome do servidor
        //Initial Catalog - Nome do banco de dados
        //User Id = Usuário
        //Password = Senha
        //Caso seja autenticação do windows não passa usuário e senha e passa integrated security=true
        private string StringConexao = @"Data Source =.\SqlExpress;initial catalog=SENAI_SVIGUFU_TARDE;user id=sa;password=132";

        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryAlteracao = "UPDATE TIPOS_EVENTOS SET TITULO = @TITULO WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(QueryAlteracao, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("@ID", tipoEvento.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            //Declaro a minha conexão e passo como parametro a String de Conexão
            using (SqlConnection con = new SqlConnection (StringConexao))
            {
                //Query que insere os dados
                //string queryInsert = "INSERT INTO TIPOS_EVENTOS(TITULO) VALUES ('" + tipoEvento.Nome + "')";
                string queryInsert = "INSERT INTO TIPOS_EVENTOS(TITULO) VALUES (@TITULO)";
                //Cria um objeto comando passando como parametro a query e a coxenão
                SqlCommand cmd = new SqlCommand(queryInsert, con);
                //Atribui o nome do evento ao parametro
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                //Abre o banco de dados
                con.Open();
                //Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Esclui um registro da base de dados pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        public void Deletar(int id)
        {
            //Declara a conexão com o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query de Delete
                string queryDelete = "DELETE FROM TIPOS_EVENTOS WHERE ID =@ID";
                //Cria um objeto SqlCommand passando a query e a conexão
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                //Atribui o id ao parametro
                cmd.Parameters.AddWithValue("@ID", id);
                //Abre o banco
                con.Open();
                //Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lista os tipos de eventos
        /// </summary>
        /// <returns>Retorna uma Lista de TipoEventoDomain</returns>
        public List<TipoEventoDomain> Listar()
        {
            //Objeto que irá retornar na chamada do método
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();
            //Define a conexão passando a string de conexão
            using  (SqlConnection con = new SqlConnection (StringConexao))
            {
                string QuerySelect = "SELECT ID, TITULO FROM TIPOS_EVENTOS";
                //Define o comando que será executado, no contrutor passa a query e a conexão
                using (SqlCommand cmd = new SqlCommand (QuerySelect, con))
                {
                    //Abro a conexão com o Banco de Dados
                    con.Open();
                    //Objeto que armazena os dados retornados da execução da instrução
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //Percorre todos os dados do objeto
                    while(rdr.Read())
                    {
                        //Crio um objeto tipo evento e atribuo os valores da tabela ao objeto
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };
                        //Adiciona o objeto na lista e tipos de eventos
                        tiposEventos.Add(tipoEvento);
                    }
                }
            }

            return tiposEventos;
        }
    }
}