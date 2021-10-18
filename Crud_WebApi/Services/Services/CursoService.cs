using Crud_WebApi.DTO;
using Crud_WebApi.Repositories.Interfaces;
using Crud_WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Services.Services
{
    public class CursoService: ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<List<CursoDto>> getAll()
        {
            return await _cursoRepository.getAll();
        }
    }
}
