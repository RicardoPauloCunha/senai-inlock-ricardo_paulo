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
        string StringConexao = "DATA source=.\\SqlExpress; initial catalog=InLock_Games_Manha; user id=sa; pwd=132";

        public List<EstudiosDomain> Listar()
        {
            string QuerySelect = "SELECT EstudioId, NomeEstudio FROM Estúdios";

            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
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

        public List<EstudiosDomain> ListarEstJog()
        {
            string QuerrySelect = "SELECT E.EstudioId, E.NomeEstudio, J.JogoId, J.NomeJogo FROM ESTUDIOS E INNER JOIN Jogos J ON E.EstudioId = J.EstudioId";

            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerrySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain
                        {
                            EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                            NomeEstudio = sdr["NomeEstudio"].ToString()
                        };

                        JogosDomain jogo = new JogosDomain
                        {
                            JogoId = Convert.ToInt32(sdr["JogoId"]),
                            NomeJogo = sdr["NomeJogo"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            EstudioId = Convert.ToInt32(sdr["EstudioId"])
                        };

                        JogosRepositorio jogosRep = new JogosRepositorio();
                        jogosRep.ListarJogDoEst(estudio.EstudioId);

                        estudios.Add(estudio);
                    }
                }
            }
            return estudios;
        }
    }
}
