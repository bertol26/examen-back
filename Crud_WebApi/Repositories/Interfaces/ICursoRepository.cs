using Crud_WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Repositories.Interfaces
{
    public interface ICursoRepository
    {
        Task<List<CursoDto>> getAll();
    }
}
