using Crud_WebApi.DTO;
using Crud_WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Controllers
{
    [Route("api/Curso")]
    [Produces("application/json")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }
        // GET: api/<ProductoController>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<CursoDto>> GetAll()
        {
            return await _cursoService.getAll();
        }
    }
}
