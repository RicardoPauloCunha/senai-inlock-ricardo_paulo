using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositorios;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepositorio EstudiosRepositorio { get; set; }

        public EstudiosController()
        {
            EstudiosRepositorio = new EstudiosRepositorio();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(EstudiosRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ListarEstudiosJogos")]
        public IActionResult ListarEstudiosJogos()
        {
            try
            {
                return Ok(EstudiosRepositorio.ListarEstJog());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}