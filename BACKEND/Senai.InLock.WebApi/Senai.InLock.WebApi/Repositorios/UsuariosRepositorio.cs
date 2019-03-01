using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        string StringConexao = "DATA source=.\\SqlExpress; initial catalog=InLock_Games_Manha; user id=sa; pwd=132";

        public UsuariosDomain BuscarUsuario(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT U.UsuarioId, U.Email, U.Senha, U.TipoUsuario FROM USUARIOS U WHERE U.Email = @Email AND U.Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuariosDomain usuario = new UsuariosDomain();

                        while (sdr.Read())
                        {
                            usuario.UsuarioId = Convert.ToInt32(sdr["UsuarioId"]);
                            usuario.Email = sdr["Email"].ToString();
                            usuario.Senha = sdr["Senha"].ToString();
                            usuario.TipoUsuario = sdr["TipoUsuario"].ToString();
                        }
                        return usuario;
                    }
                }
                return null;
            }
        }
    }
}
