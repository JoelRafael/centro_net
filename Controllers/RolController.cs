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
    public class RolController : ControllerBase
    {
        private readonly cursodbContext _ctx;
        public RolController(cursodbContext ctx)
        {
            this._ctx = ctx;
        }
        //  public DateTime Date { get; }


        [HttpGet]

        public async Task<IEnumerable<Rol>> GetRol()
        {

            return await _ctx.Rols.ToListAsync();
        }


        [HttpPost]
        public async Task<IActionResult> PosRol(Rol data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }


            if (await _ctx.Rols.Where(x => x.Name == data.Name).AnyAsync())
            {
                return BadRequest(new { error = true, message = "Este rol ya existe" });
            }
            var rol = new Rol
            {
                Name = data.Name,
                CreateAt = DateHelpers.Responsedate()
            };

            _ctx.Add(rol);
            await _ctx.SaveChangesAsync();
            return StatusCode(201, new { error = false, message = "Se ha creado un rol" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updaterol(int id, Rol data)
        {

            if (id != data.Id)
            {
                return BadRequest(new { error = true, message = "El id no coincide con el solicitado" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }
            var rol = await _ctx.Rols.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (rol == null)
            {
                return NotFound(new { error = true, message = "Este rol no existe" });
            }
            else
            {
                rol.Name = data.Name;
                rol.UpdateAt = DateHelpers.Responsedate();
                await _ctx.SaveChangesAsync();
                return StatusCode(201, new { error = false, message = "Rol actualizado" });
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _ctx.Rols
                          .Include(x => x.Usuarios)
                          .Where(x => x.Id == id).SingleOrDefaultAsync();

            if (rol == null)
            {
                return NotFound(new { error = true, message = "Este rol no existe" });
            }
            if (rol.Usuarios.Count > 0)
            {
                return BadRequest(new { error = true, message = "Este rol tiene un usuario asignado" });
            }
            _ctx.Rols.Remove(rol);
            await _ctx.SaveChangesAsync();
            return StatusCode(200, new { error = false, message = "Rol Eliminado" });
        }
    }
}