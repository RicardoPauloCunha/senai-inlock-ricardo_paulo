using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class EstudiosDomain
    {
        public int EstudioId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Estudio")]
        public string NomeEstudio { get; set; }
    }
}
