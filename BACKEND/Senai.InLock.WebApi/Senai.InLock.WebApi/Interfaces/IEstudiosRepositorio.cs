using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudiosRepositorio
    {
        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns></returns>
        List<EstudiosDomain> Listar();

        List<EstudiosDomain> ListarEstJog();
    }
}
