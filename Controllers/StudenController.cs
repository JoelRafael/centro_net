using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CentroNet.Models;
using CentroNet.Helpers;
using Microsoft.AspNetCore.Authorization;
namespace CentroNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudenController : ControllerBase
    {
        private readonly cursodbContext _ctx;

        public StudenController(cursodbContext ctx)
        {
            this._ctx = ctx;
        }
        [HttpGet("consultar/estudiantes")]
        [Authorize]
        public async Task<IEnumerable<Estudiante>> GetStuden()
        {
            return await _ctx.Estudiantes.Include(p => p.IdDatospadreNavigation)
                                          .Include(t => t.IdtutorNavigation)
                                          .Include(f => f.FichaMedicaEstudiantes)
                                          .Include(m => m.Matriculas).ToListAsync();


        }
        [HttpPost("registrar/estudiante")]
        public async Task<IActionResult> PostStudent(Estudiante data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }
            var consult = await _ctx.Estudiantes.Where(x => x.number_certificate == data.number_certificate).AnyAsync();
            if (consult)
            {
                return BadRequest(new { error = true, message = "Ya este estudiante existe" });
            }
            var studen = new Estudiante
            {
                Iduser = data.Iduser,
                Names = data.Names,
                Lastnames = data.Lastnames,
                Birthdate = data.Birthdate,
                Status = data.Status,
                CreateAt = DateHelpers.Responsedate(),
                IdDatospadre = data.IdDatospadre,
                Idtutor = data.Idtutor,
                Idgenero = data.Idgenero,
                number_certificate = data.number_certificate
            };
            _ctx.Estudiantes.Add(studen);
            await _ctx.SaveChangesAsync();
            var veryfy = await _ctx.Estudiantes.Where(x => x.number_certificate == data.number_certificate).SingleOrDefaultAsync();
            var max = await _ctx.Matriculas.OrderByDescending(x => x.Code).FirstOrDefaultAsync();
            if (max == null)
            {
                var year = DateHelpers.ResponsedateMa().ToString("yy");
                var month = DateHelpers.ResponsedateMa().ToString("MM");
                var day = DateHelpers.ResponsedateMa().ToString("dd");
                string code = year + month + day;
                int result = Int32.Parse(code);

                var codes = new Matricula
                {
                    Idstuden = veryfy.Id,
                    Code = result,
                    CreateAt = DateHelpers.Responsedate(),
                    Status = true
                };
                _ctx.Matriculas.Add(codes);
                await _ctx.SaveChangesAsync();
                return StatusCode(201, new { error = false, message = "Estudiante creado con existo" });
            }
            else
            {
                int codemat = max.Code + 1;
                var codes = new Matricula
                {
                    Idstuden = veryfy.Id,
                    Code = codemat,
                    CreateAt = DateHelpers.Responsedate(),
                    Status = true
                };
                _ctx.Matriculas.Add(codes);
                await _ctx.SaveChangesAsync();
                return StatusCode(201, new { error = false, message = "Estudiante creado con existo" });
            }

        }

    }
}