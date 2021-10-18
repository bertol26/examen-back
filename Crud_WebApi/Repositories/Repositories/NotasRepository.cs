using Crud_WebApi.Context;
using Crud_WebApi.DTO;
using Crud_WebApi.Models;
using Crud_WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Repositories.Repositories
{
    public class NotasRepository : INotasRepository
    {
        private readonly DbContextExamen contexto;

        public NotasRepository(DbContextExamen _contexto)
        {
            contexto = _contexto;
        }
        public async Task<int> Create(NotasDto entity)
        {
            var promPracticas = 0.0;
            var promFinal = 0.0;

            if (entity.Practica1 != null && entity.Practica2 != null && entity.Practica3 != null)
            {
                promPracticas = (entity.Practica1 + entity.Practica2 + entity.Practica3) / 3;
            }

            if (entity.Parcial != null && entity.Final != null)
            {
                promFinal = (promPracticas + entity.Parcial + entity.Final) / 3;
            }


            var notas = new Notas()
            {
                Id = 0,
                IdCurso = (int)entity.IdCurso,
                IdAlumno = (int)entity.IdAlumno,
                Practica1 = entity.Practica1,
                Practica2 = entity.Practica2,
                Practica3 = entity.Practica3,
                Parcial = entity.Parcial,
                Final = entity.Final,
                PromedioFinal = promFinal
            };

           await contexto.Ap_Franco_Bertol_Notas.AddAsync(notas);
           var result = await contexto.SaveChangesAsync();
            return result;
        }

        public async Task<NotasDto> GetByAlumnoCurso(int idAlumno, int idCurso)
        {
            var nota = await (from p in contexto.Ap_Franco_Bertol_Notas
                        where p.IdCurso == idCurso && p.IdAlumno == idAlumno
                        select new NotasDto
                        {
                            Id = p.Id,
                            IdAlumno = p.IdAlumno,
                            IdCurso = p.IdCurso,
                            Practica1 = p.Practica1,
                            Practica2 = p.Practica2,
                            Practica3 = p.Practica3,
                            Parcial = p.Parcial,
                            Final = p.Final,
                            PromedioFinal = p.PromedioFinal
                        }).FirstOrDefaultAsync();
            return nota;
        }

        public async Task<int> Update(NotasDto entity)
        {
            var promPracticas = 0.0;
            var promFinal = 0.0;

            if (entity.Practica1 != null && entity.Practica2 != null && entity.Practica3 != null)
            {
                promPracticas = (entity.Practica1 + entity.Practica2 + entity.Practica3) / 3;
            }

            if (entity.Parcial != null && entity.Final != null)
            {
                promFinal = (promPracticas + entity.Parcial + entity.Final) / 3;
            }


            var notas = new Notas()
            {
                Id = (int)entity.Id,
                IdCurso = (int)entity.IdCurso,
                IdAlumno = (int)entity.IdAlumno,
                Practica1 = entity.Practica1,
                Practica2 = entity.Practica2,
                Practica3 = entity.Practica3,
                Parcial = entity.Parcial,
                Final = entity.Final,
                PromedioFinal = promFinal
            };

            contexto.Ap_Franco_Bertol_Notas.Update(notas);
            var result = await contexto.SaveChangesAsync();
            return result;
        }
    }
}
