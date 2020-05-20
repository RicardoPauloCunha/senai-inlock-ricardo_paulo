using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositorios
{
    public class JogosRepositorio : IJogosRepositorio
    {
        readonly string stringConexao = "DATA source=.\\SQLSERVERJIROS; initial catalog=InLock_Games; user id=sa; pwd=ji_15?27101001_roS";

        public void Cadastrar(JogosViewModel jogo)
        {
            string QueryInsert = "INSERT INTO JOGOS(NomeJogo, Descricao, DataLancamento, Valor, EstudioId) VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor, @EstudioId)";

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@EstudioId", jogo.EstudioId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> Listar()
        {
            string QuerySelect = "SELECT J.JogoId, J.NomeJogo, J.Descricao, J.DataLancamento, J.Valor, J.EstudioId, E.EstudioId, E.NomeEstudio FROM JOGOS J INNER JOIN ESTUDIOS E ON J.EstudioId = E.EstudioId";
            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            JogoId = Convert.ToInt32(sdr["JogoId"]),
                            NomeJogo = sdr["NomeJogo"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            Estudio = new EstudiosDomain
                            {
                                EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                                NomeEstudio = sdr["NomeEstudio"].ToString()
                            }
                        };

                        jogos.Add(jogo);
                    }
                }
            }

            return jogos;
        }

        public List<JogosDomain> ListarJogDoEst(int estudioId)
        {
            string QuerySelect = "SELECT JogoId, NomeJogo, Descricao, DataLancamento, Valor, EstudioId FROM JOGOS WHERE EstudioId = @EstudioId;";

            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EstudioId", estudioId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            JogoId = Convert.ToInt32(sdr["JogoId"]),
                            NomeJogo = sdr["NomeJogo"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            EstudioId = Convert.ToInt32(sdr["EstudioId"])
                        };

                        jogos.Add(jogo);
                    }
                }
            }
            return jogos;
        }
    }
}
