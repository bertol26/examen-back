using Crud_WebApi.DTO;
using Crud_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Repositories.Interfaces
{
    public interface IAlumnoRepository
    {
        Task<List<AlumnoDto>> GetAll();
        Task<AlumnoDto> GetById(int id);
        Task<int> AddAlumno(AlumnoDto entity);
        Task<int> UpdateAlumno(AlumnoDto entity);
        Task<int> DeleteAlumno(int id);
    }
}
