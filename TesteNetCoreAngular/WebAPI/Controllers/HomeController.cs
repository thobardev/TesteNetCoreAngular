using Data.Abstract;
using Data.Context;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger<WeatherForecastController> _logger;

        //public HomeController(ILogger<WeatherForecastController> logger)
        //{
        //    //_logger = logger;
        //}

        IUsuarioRepository usuarioRepository;
        IEscolaridadeRepository escolaridadeRepository;

        public HomeController(IUsuarioRepository usuarioRepository, IEscolaridadeRepository escolaridadeRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.escolaridadeRepository = escolaridadeRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            try
            {
                var usuario = usuarioRepository.Get(id);
                var usuarioModel = usuario.ToUsuarioModel();

                return Ok(usuarioModel);
            }
            catch (Exception ex)
            {
                var error = new ErrorModel();
                error.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }


        [HttpGet(Name = "GetHome")]
        public IActionResult GetUsuarios()
        {
            try
            {
                var usuarios = usuarioRepository.GetAll();
                IEnumerable<UsuarioModel> usuariosModel = usuarios.ToUsuarioModelList();

                return Ok(usuariosModel);
            }
            catch (Exception ex)
            {
                var error = new ErrorModel();
                error.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                usuarioRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                var error = new ErrorModel();
                error.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }

        }

        [HttpPost()]
        public IActionResult Save(UsuarioModel usuario)
        {
            try
            {

                if (usuario.Id == 0)
                    usuarioRepository.Add(usuario.ToUsuario());
                else
                    usuarioRepository.Update(usuario.ToUsuario());

                return NoContent();
            }
            catch (Exception ex)
            {
                var error = new ErrorModel();
                error.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        [HttpGet("escolaridades/")]
        public IActionResult GetEscolaridades()
        {
            try
            {
                IEnumerable<Escolaridade> escolaridades = escolaridadeRepository.GetAll();
                return Ok(escolaridades.ToEscolaridadeModelList());
            }
            catch (Exception ex)
            {
                var error = new ErrorModel();
                error.Message = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }

        }

    }
}
