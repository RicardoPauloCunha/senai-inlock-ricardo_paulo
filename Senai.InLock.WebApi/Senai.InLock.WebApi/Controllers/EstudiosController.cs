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
        private readonly IEstudiosRepositorio _estudiosRepositorio;

        public EstudiosController()
        {
            _estudiosRepositorio = new EstudiosRepositorio();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_estudiosRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}