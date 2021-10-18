using Crud_WebApi.Context;
using Crud_WebApi.DTO;
using Crud_WebApi.Models;
using Crud_WebApi.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Repositories.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly DbContextExamen context;
        public AlumnoRepository(DbContextExamen _context)
        {
            context = _context;
        }

        public async Task<int> AddAlumno(AlumnoDto entity)
        {
            var alumno = new Alumno()
            {
                Apellidos = entity.Apellidos,
                Nombres = entity.Nombres,
                FechaNacimiento = entity.FechaNacimiento,
                Sexo = entity.Sexo,
                Id = 0
            };
             await context.Ap_Franco_Bertol_Alumno.AddAsync(alumno);
             var result = await context.SaveChangesAsync();
             return result;
        }

        public Task<int> DeleteAlumno(int id)
        {
            var alumno = context.Ap_Franco_Bertol_Alumno.Find(id);
            if (alumno != null)
            {
                context.Ap_Franco_Bertol_Alumno.Remove(alumno);
            }

            var result = context.SaveChangesAsync();
            return result;
        }

        public Task<List<AlumnoDto>> GetAll()
        {
            var alumnos = (from p in context.Ap_Franco_Bertol_Alumno
                           select new AlumnoDto
                           {
                               Apellidos = p.Apellidos,
                               Nombres = p.Nombres,
                               FechaNacimiento = p.FechaNacimiento,
                               Id = p.Id,
                               Sexo = p.Sexo
                           }).ToListAsync();
            return alumnos;
        }

        public async Task<AlumnoDto> GetById(int id)
        {
            var alumno = await (from p in context.Ap_Franco_Bertol_Alumno where p.Id == id
                           select new AlumnoDto
                           {
                               Apellidos = p.Apellidos,
                               Nombres = p.Nombres,
                               FechaNacimiento = p.FechaNacimiento,
                               Id = p.Id,
                               Sexo = p.Sexo
                           }).FirstOrDefaultAsync();
            return alumno;
        }

        public async Task<int> UpdateAlumno(AlumnoDto entity)
        {
            var alumno = new Alumno()
            {
                Apellidos = entity.Apellidos,
                Nombres = entity.Nombres,
                FechaNacimiento = entity.FechaNacimiento,
                Sexo = entity.Sexo,
                Id = (int)entity.Id
            };
            context.Ap_Franco_Bertol_Alumno.Update(alumno);
            var result = await context.SaveChangesAsync();
            return result;
        }
    }
}
