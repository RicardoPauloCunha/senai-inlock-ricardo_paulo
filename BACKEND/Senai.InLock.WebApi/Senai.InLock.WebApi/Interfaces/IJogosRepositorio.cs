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
        void Cadastrar(JogosDomain jogo);

        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos</returns>
        List<JogosDomain> Listar();

        List<JogosDomain> ListarJogDoEst(int estudioId);
    }
}
