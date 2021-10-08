using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CentroNet.Models;
using CentroNet.Helpers;
namespace CentroNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly cursodbContext _ctx;
        public GenderController(cursodbContext ctx)
        {
            this._ctx = ctx;
        }
        [HttpGet("consulta/genero")]
        public async Task<IEnumerable<Genero>> GetGender()
        {
            return await _ctx.Generos.ToListAsync(); ;
        }
        [HttpPost("crear/genero")]
        public async Task<IActionResult> Postgender(Genero gende)
        {
            if (gende.Gender == "")
            {
                return BadRequest(new { error = true, message = "No se aceptan campo vacios" });
            }
            if (await _ctx.Generos.Where(x => x.Gender == gende.Gender).AsNoTracking().AnyAsync())
            {
                return BadRequest(new { error = true, message = "Este genero existe" });
            }
            _ctx.Add(gende);
            await _ctx.SaveChangesAsync();
            return StatusCode(201, new { error = false, message = "Genero creado" });
        }
        [HttpPut("actualizar/genero/{id}/{gender}")]

        public async Task<IActionResult> UpdateGender(int id, string gender)
        {


            var genders = await _ctx.Generos.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (genders == null)
            {
                return NotFound(new { error = true, message = "Este genero no existe" });
            }
            var validate_genders = await _ctx.Generos.Where(x => x.Gender == gender).AnyAsync();

            if (validate_genders == true)
            {
                return BadRequest(new { error = true, message = "Este genero existe" });
            }
            genders.Gender = gender;
            await _ctx.SaveChangesAsync();
            return StatusCode(201, new { error = false, message = "Genero actualizado" });
        }


        [HttpDelete("borrar/genero/{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var consult = await _ctx.Generos.Include(x => x.Estudiantes).Where(x => x.Id == id).SingleOrDefaultAsync();
            if (consult == null)
            {
                return NotFound(new { error = true, message = "Este genero no existe" });
            }
            if (consult.Estudiantes.Count > 0)
            {
                return BadRequest(new { error = true, message = "Este genero tiene un estudiante" });
            }
            _ctx.Generos.Remove(consult);
            await _ctx.SaveChangesAsync();
            return StatusCode(200, new { error = false, message = "Genero eliminado" });
        }

    }
}