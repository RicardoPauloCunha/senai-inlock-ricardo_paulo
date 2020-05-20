using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositorios
{
    public class EstudiosRepositorio : IEstudiosRepositorio
    {
        readonly string stringConexao = "DATA source=.\\SQLSERVERJIROS; initial catalog=InLock_Games; user id=sa; pwd=ji_15?27101001_roS";

        public List<EstudiosDomain> Listar()
        {
            string QuerySelect = "SELECT EstudioId, NomeEstudio FROM ESTUDIOS";

            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain
                        {
                            EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                            NomeEstudio = sdr["NomeEstudio"].ToString()
                        };

                        estudios.Add(estudio);
                    }
                }
            }
            return estudios;
        }
    }
}
