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
        /// <returns>Retona uma lista de estudios</returns>
        List<EstudiosDomain> Listar();
    }
}
