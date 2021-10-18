using Crud_WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Services.Interfaces
{
    public interface ICursoService
    {
        Task<List<CursoDto>> getAll();
    }
}
