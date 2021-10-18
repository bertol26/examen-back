using Crud_WebApi.Context;
using Crud_WebApi.DTO;
using Crud_WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Repositories.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly DbContextExamen contexto;

        public CursoRepository(DbContextExamen _contexto)
        {
            contexto = _contexto;
        }

        public async Task<List<CursoDto>> getAll()
        {
            var cursos = await (from p in contexto.Ap_Franco_Bertol_Curso
                          select new CursoDto
                          {
                              Id = p.Id,
                              Descripcion = p.Descripcion,
                              Nombre = p.Nombre,
                              Obligatoriedad = p.Obligatoriedad
                          }).ToListAsync();
            return cursos;
        }
    }
}
