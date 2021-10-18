using Crud_WebApi.DTO;
using Crud_WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crud_WebApi.Controllers
{
    [Route("api/Alumno")]
    [Produces("application/json")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;

        public AlumnoController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }
        // GET: api/<ProductoController>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<AlumnoDto>> GetAll()
        {
            return await _alumnoService.GetAll();
        }

        // GET api/<ProductoController>/5
        [HttpGet("GetById/{id}")]
        public async Task<AlumnoDto> GetById(int id)
        {
            return await _alumnoService.GetById(id);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(AlumnoDto alumno)
        {
            var result = await _alumnoService.AddAlumno(alumno);
            if (result == 1) return Ok(result); else return NotFound(); 
        }

        // PUT api/<ProductoController>/5
        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] AlumnoDto alumno)
        {
            var result = await _alumnoService.UpdateAlumno(alumno);
            if (result == 1) return Ok(result); else return NotFound();
            
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _alumnoService.DeleteAlumno(id);
            if (result == 1) return Ok(result); else return NotFound();
        }
    }
}
