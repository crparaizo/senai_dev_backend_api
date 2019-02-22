using Senai.Svigufo.WebApi.Domains;
using Senai.Svigufo.WebApi.Interfaces;
using System;
using System.Data.SqlClient;

namespace Senai.Svigufo.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=SENAI_SVIGUFU_TARDE;Persist Security Info=True;User ID=sa;Password=132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, NOME, EMAIL, TIPO_USUARIO FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain();

                        while (sdr.Read())
                        {
                            usuarioBuscado.Id = Convert.ToInt32(sdr["ID"]);
                            usuarioBuscado.Nome = sdr["NOME"].ToString();
                            usuarioBuscado.Email = sdr["EMAIL"].ToString();
                            usuarioBuscado.TipoUsuario = sdr["TIPO_USUARIO"].ToString();
                        }

                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            string QueryInsert = "INSERT INTO USUARIOS (NOME, EMAIL, SENHA, TIPO_USUARIO) VALUES (@NOME, @EMAIL, @SENHA, @TIPO_USUARIO)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOME", usuario.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
                    cmd.Parameters.AddWithValue("@SENHA", usuario.Senha);
                    cmd.Parameters.AddWithValue("@TIPO_USUARIO", usuario.TipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}