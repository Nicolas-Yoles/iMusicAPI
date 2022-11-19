using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using back_end.Filtros;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILogger<GenerosController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController( 
            ILogger<GenerosController> logger,
            ApplicationDbContext context,
            IMapper mapper

            )
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] // api/generos
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            //return await context.Generos.ToListAsync();
            
            var generos = await context.Generos.ToListAsync();

            //var resultado = new List<GeneroDTO>();
            //foreach (var genero in generos)
            //{
            //    resultado.Add(new GeneroDTO() { Id = genero.Id, Nombre = genero.Nombre });
            //}

            //return resultado;

            return mapper.Map<List<GeneroDTO>>(generos);

        }


        [HttpGet("{Id:int}")]
        public Task<ActionResult<Genero>> Get(int Id)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }
    }
}
