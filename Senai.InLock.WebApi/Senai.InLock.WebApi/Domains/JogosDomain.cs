using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogosDomain
    {
        public int JogoId { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento{ get; set; }
        public decimal Valor { get; set; }
        public int EstudioId{ get; set; }
        public EstudiosDomain Estudio { get; set; }
    }
}
