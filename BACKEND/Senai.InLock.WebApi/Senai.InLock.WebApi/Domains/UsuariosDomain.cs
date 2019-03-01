using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuariosDomain
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Senha Inválida, deve conter mais de 3 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o Tipo de Usuário")]
        public string TipoUsuario { get; set; }
    }
}
