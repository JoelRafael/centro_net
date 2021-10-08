using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CentroNet.Models;
using CentroNet.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
namespace CentroNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginControllercs : ControllerBase
    {
        private readonly cursodbContext _ctx;
        private readonly IConfiguration conf;

        public LoginControllercs(cursodbContext ctx, IConfiguration config)
        {
            this._ctx = ctx;
            this.conf = config;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }
            var consul = await _ctx.Usuarios.Where(x => x.Users == data.Users).SingleOrDefaultAsync();
            if (consul == null)
            {
                return NotFound(new { error = true, message = "El usuario es incorrecto" });
            }
            //consul.Password;
            string verify = HashHelpers.ConvertToDescrypt(consul.Passwords);
            if (verify != data.Passwords)
            {
                return NotFound(new { error = true, message = "El usuario o el password es incorrecto" });
            }

            string secret = this.conf.GetValue<string>("SecretKey");
            var jwtHelpers = new JWTHelpers(secret);
            string token = jwtHelpers.CreateToken(consul.Users);

            return StatusCode(200, new { error = false, message = "Logeado con exito", tokens = token, user = consul, });
        }


    }
}