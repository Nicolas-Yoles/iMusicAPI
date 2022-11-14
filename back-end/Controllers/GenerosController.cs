using back_end.Entidades;
using back_end.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace back_end.Controllers
{
    [Route("api/generos")]
    public class GenerosController: ControllerBase
    {
        private IRepositorio repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet] // api/generos
        [HttpGet("listado")] // api/generos/listado
        public List<Genero> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("{Id:int}")] // api/generos/1
        public Genero Get(int Id, string nombre)
        {
            var genero = repositorio.ObtenerPorId(Id);

            if (genero == null)
            {
                //return NotFound();
            }

            return genero;
        }
        
        [HttpPost]
        public void Post()
        {

        }

        [HttpPut]
        public void Put()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}
