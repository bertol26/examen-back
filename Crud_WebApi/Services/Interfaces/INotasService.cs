using Crud_WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Services.Interfaces
{
    public interface INotasService
    {
        Task<NotasDto> GetByAlumnoCurso(int idAlumno, int idCurso);
        Task<int> Create(NotasDto entity);
        Task<int> Update(NotasDto entity);
    }
}
