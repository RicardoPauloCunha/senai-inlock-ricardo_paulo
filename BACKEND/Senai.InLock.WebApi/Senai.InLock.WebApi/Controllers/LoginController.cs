using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositorios;
using Senai.InLock.WebApi.ViewModels;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepositorio UsuarioRepositorio { get; set; }

        public LoginController()
        {
            UsuarioRepositorio = new UsuariosRepositorio();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                UsuariosDomain UsuarioBuscado = UsuarioRepositorio.BuscarUsuario(login.Email, login.Senha);

                if(UsuarioBuscado == null)
                {
                    return NotFound(new { mesagem = "Email ou Senha Inválida" });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InLock.WebApi",
                    audience: "InLock.WebApi", 
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}