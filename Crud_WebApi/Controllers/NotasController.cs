using Crud_WebApi.DTO;
using Crud_WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Controllers
{
    [Route("api/Notas")]
    [Produces("application/json")]
    [ApiController]
    public class NotasController : Controller
    {
        private readonly INotasService _notasService;

        public NotasController(INotasService notasService)
        {
            _notasService = notasService;
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Create(NotasDto notas)
        {
            var result = await _notasService.Create(notas);
            if (result == 1) return Ok(result); else return NotFound();
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update(NotasDto notas)
        {
            var result = await _notasService.Update(notas);
            if (result == 1) return Ok(result); else return NotFound();
        }

        // GET api/<ProductoController>/5
        [HttpGet("GetByIdAlumno/{idAlumno}/{idCurso}")]
        public async Task<NotasDto> GetByIdAlumno(int idAlumno, int idCurso)
        {
            return await _notasService.GetByAlumnoCurso(idAlumno, idCurso);
        }
    }
}
