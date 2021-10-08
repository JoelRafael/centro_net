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
    public class UserController : ControllerBase
    {
        private readonly cursodbContext _ctx;
        public UserController(cursodbContext ctx)
        {
            this._ctx = ctx;
        }
        [HttpGet("consulta/usuario")]
        public async Task<IEnumerable<Usuario>> GetUser()
        {
            var user = await _ctx.Usuarios
            .Include(x => x.IdRolNavigation)
            .ToListAsync();
            return user;
        }
        [HttpPost("crear/usuario")]
        public async Task<IActionResult> PostUser(Usuario data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }
            var user = new Usuario
            {
                Users = data.Users,
                Passwords = HashHelpers.ConvertToEncrypt(data.Passwords),
                IdRol = data.IdRol,
                CreateAt = DateHelpers.Responsedate()
            };
            _ctx.Add(user);
            await _ctx.SaveChangesAsync();
            return StatusCode(201, new { error = false, message = "Usuario creado con existo" });


        }

        [HttpPut("cambiar/password/{id}")]
        public async Task<IActionResult> ChangePassword(int id, Changepassword change)
        {
            if (id != change.Id)
            {
                return BadRequest(new { error = true, message = "Los id no coinciden" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }
            var user = await _ctx.Usuarios.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new { error = true, message = "Este usuario no existe" });

            }
            else
            {
                user.Passwords = HashHelpers.ConvertToEncrypt(change.Password);
                user.UpdateAt = DateHelpers.Responsedate();
                await _ctx.SaveChangesAsync();
                return StatusCode(201, new { error = false, message = "Se ha cambiado la clave del usuario" });
            }
        }

        [HttpPut("cambiar/estatus/{id}/{status}")]
        public async Task<IActionResult> ChangeStatus(int id, bool status)
        {

            var user = await _ctx.Usuarios.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new { error = true, message = "Este usuario no existe" });

            }
            else
            {
                user.Status = status;
                user.UpdateAt = DateHelpers.Responsedate();
                await _ctx.SaveChangesAsync();
                return StatusCode(201, new { error = false, message = "Estado cambiado" });
            }
        }

        [HttpPut("cambiar/rol/{id}/{rol}")]
        public async Task<IActionResult> ChangeRol(int id, int rol)
        {

            var user = await _ctx.Usuarios.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (user == null)
            {
                return NotFound(new { error = true, message = "Este usuario no existe" });

            }
            else
            {
                user.IdRol = rol;
                user.UpdateAt = DateHelpers.Responsedate();
                await _ctx.SaveChangesAsync();
                return StatusCode(201, new { error = false, message = "Rol cambiado" });
            }
        }
    }
}