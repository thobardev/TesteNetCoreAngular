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
        public async Task<IActionResult> GetUsuario(int id)
        {
            try
            {
                var usuario = await usuarioRepository.GetAsync(id);
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
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var usuarios = await usuarioRepository.GetAllAsync();
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await usuarioRepository.DeleteAsync(id);
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
        public async Task<IActionResult> Save(UsuarioModel usuario)
        {
            try
            {
                if (usuario.DataNascimento > DateTime.Now)
                    throw new ApplicationException("A data de nascimento não pode ser maior do que o dia atual");

                if (usuario.Id == 0)
                    await usuarioRepository.AddAsync(usuario.ToUsuario());
                else
                    await usuarioRepository.UpdateAsync(usuario.ToUsuario());

                return NoContent();
            }
            catch (Exception ex)
            {
                var error = new ErrorModel();
                error.Message = ex.Message;
                int statusCode = ex is ApplicationException? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError;

                return StatusCode(statusCode, error);
            }
        }

        [HttpGet("escolaridades/")]
        public async Task<IActionResult> GetEscolaridades()
        {
            try
            {
                IEnumerable<Escolaridade> escolaridades = await escolaridadeRepository.GetAllAsync();
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
