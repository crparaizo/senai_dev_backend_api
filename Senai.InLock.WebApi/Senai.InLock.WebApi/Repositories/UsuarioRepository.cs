using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Data.SqlClient;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = @"Data Source =.\SqlExpress;initial catalog=InLock_Games_Tarde;user id=sa;password=132";

        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT Email, Senha, TipoUsuario FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain();

                        while (sdr.Read())
                        {
                            usuarioBuscado.UsuarioId = Convert.ToInt32(sdr["UsuarioId"]);
                            usuarioBuscado.Email = sdr["Email"].ToString();
                            usuarioBuscado.TipoUsuario = sdr["TipoUsuario"].ToString();
                        }

                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }
    }
}