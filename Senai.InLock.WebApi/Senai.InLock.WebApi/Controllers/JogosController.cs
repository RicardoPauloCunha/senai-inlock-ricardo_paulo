using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositorios;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepositorio _jogosRepositorio { get; set; }

        public JogosController()
        {
            _jogosRepositorio = new JogosRepositorio();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(JogosViewModel jogo)
        {
            try
            {
                _jogosRepositorio.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_jogosRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}