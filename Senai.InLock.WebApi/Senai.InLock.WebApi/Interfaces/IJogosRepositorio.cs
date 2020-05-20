using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogosRepositorio
    {
        /// <summary>
        /// Cadastra um novo Jogo
        /// </summary>
        /// <param name="jogo">Jogo</param>
        void Cadastrar(JogosViewModel jogo);

        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos</returns>
        List<JogosDomain> Listar();

        /// <summary>
        /// Lista todos os jogos de um estudio
        /// </summary>
        /// <param name="estudioId">Id do estudio</param>
        /// <returns>Retorna de jogos do estudio</returns>
        List<JogosDomain> ListarJogDoEst(int estudioId);
    }
}
