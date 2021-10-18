using Crud_WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Repositories.Interfaces
{
    public interface INotasRepository
    {
        Task<NotasDto> GetByAlumnoCurso(int idAlumno, int idCurso);
        Task<int> Create(NotasDto entity);
        Task<int> Update(NotasDto entity);
    }
}
