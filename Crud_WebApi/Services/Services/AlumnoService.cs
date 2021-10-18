using Crud_WebApi.DTO;
using Crud_WebApi.Repositories.Interfaces;
using Crud_WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Services.Services
{
    public class AlumnoService: IAlumnoService
    {
        private readonly IAlumnoRepository _alumnoRepository;

        public AlumnoService(IAlumnoRepository alumnoRepository)
        {
            _alumnoRepository = alumnoRepository;
        }

        public async Task<int> AddAlumno(AlumnoDto entity)
        {
            return await _alumnoRepository.AddAlumno(entity);
        }

        public async Task<int> DeleteAlumno(int id)
        {
            return await _alumnoRepository.DeleteAlumno(id);
        }

        public async Task<List<AlumnoDto>> GetAll()
        {
            return await _alumnoRepository.GetAll();
        }

        public async Task<AlumnoDto> GetById(int id)
        {
            return await _alumnoRepository.GetById(id);
        }

        public async Task<int> UpdateAlumno(AlumnoDto entity)
        {
            return await _alumnoRepository.UpdateAlumno(entity);
        }
    }
}
