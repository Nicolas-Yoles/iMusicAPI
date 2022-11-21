﻿using AutoMapper;
using back_end.DTOs;
using back_end.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/cines")]
    public class CinesController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CinesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult> Get(ApplicationDbContext context)
        //{

        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CineCreacionDTO cineCreacionDTO)
        {
            var cine = mapper.Map<Cine>(cineCreacionDTO);
            context.Add(cine);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
