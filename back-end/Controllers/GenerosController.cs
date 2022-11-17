using back_end.Entidades;
using back_end.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController: ControllerBase
    {
        private IRepositorio repositorio;
        private readonly WeatherForecastController weatherForecastController;
        private readonly ILogger<GenerosController> logger;

        public GenerosController(IRepositorio repositorio, WeatherForecastController weatherForecastController,
            ILogger<GenerosController> logger)
        {
            this.repositorio = repositorio;
            this.weatherForecastController = weatherForecastController;
            this.logger = logger;
        }

        [HttpGet] // api/generos
        [HttpGet("listado")] // api/generos/listado
        [HttpGet("/listadogeneros")] // /listadogeneros
        //[ResponseCache(Duration = 60
        public ActionResult<List<Genero>> Get()
        {
            logger.LogInformation("Vamos a mostrar los generos");
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("guid")]
        public ActionResult<Guid> GetGuid()
        {
            return Ok(new
            {
                GUID_GenerosController = repositorio.ObtenerGuid(),
                GUID_WeatherForecastController = weatherForecastController.ObtenerGUIDWeatherForecastController()
            });
        }

        [HttpGet("{Id:int}")] // api/generos/1
        public async Task<ActionResult<Genero>> Get(int Id, [FromHeader] string nombre)
        {

            logger.LogDebug($"Obteniendo un genero por el id {Id}");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var genero = await repositorio.ObtenerPorId(Id);

            if (genero == null)
            {
                logger.LogWarning($"No pudimos encontrar el genero de id {Id}");
                return NotFound();
            }

            return genero;
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] Genero genero)
        {
            repositorio.CrearGenero(genero);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Genero genero)
        {
            return NoContent();
        }
    }
}
