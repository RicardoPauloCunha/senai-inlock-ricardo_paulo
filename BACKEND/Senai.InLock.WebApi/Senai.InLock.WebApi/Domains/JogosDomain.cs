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

        [Required(ErrorMessage = "Informe o Nome do Jogo")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "Informe a Descrição do Jogo")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a Data de Lançamento do Jogo")]
        public DateTime DataLancamento{ get; set; }

        [Required(ErrorMessage = "Informe o Valor do Jogo")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Informe o Estúdio do Jogo")]
        public int EstudioId{ get; set; }

        public EstudiosDomain Estudio { get; set; }
    }
}
