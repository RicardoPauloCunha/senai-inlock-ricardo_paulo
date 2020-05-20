using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuariosRepositorio
    {
        /// <summary>
        /// Busca um usuário pelo email e senha
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o usuário encontrado</returns>
        UsuariosDomain BuscarUsuario(string email, string senha);
    }
}
