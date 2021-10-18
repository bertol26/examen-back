using Crud_WebApi.DTO;
using Crud_WebApi.Repositories.Interfaces;
using Crud_WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Services.Services
{
    public class NotasService: INotasService
    {
        private readonly INotasRepository _notasRepository;

        public NotasService(INotasRepository notasRepository)
        {
            _notasRepository = notasRepository;
        }
        public async Task<int> Create(NotasDto entity)
        {
            return await _notasRepository.Create(entity);
        }

        public async Task<NotasDto> GetByAlumnoCurso(int idAlumno, int idCurso)
        {
            return await _notasRepository.GetByAlumnoCurso(idAlumno, idCurso);
        }

        public async Task<int> Update(NotasDto entity)
        {
            return await _notasRepository.Update(entity);
        }
    }
}
