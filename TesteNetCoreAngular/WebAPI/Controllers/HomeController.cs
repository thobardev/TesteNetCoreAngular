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

        public HomeController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuarios(int id)
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
                error.HasError = true;
                error.MessageError = ex.Message;
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
                error.HasError = true;
                error.MessageError = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                return NoContent();
            }
            catch (Exception ex)
            {
                var error = new ErrorModel();
                error.HasError = true;
                error.MessageError = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }

        }

        [HttpPost()]
        public IActionResult Update(UsuarioModel usuario)
        {
            ErrorModel errorModel = new ErrorModel();
            try
            {
                usuarioRepository.Update(usuario.ToUsuario());

                return NoContent();
            }
            catch (Exception ex)
            {
                var error = new ErrorModel();
                error.HasError = true;
                error.MessageError = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }

        }

    }
}
