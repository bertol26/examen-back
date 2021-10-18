using Crud_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Context
{
    public class DbContextExamen: DbContext
    {
        public DbContextExamen(DbContextOptions<DbContextExamen> options)
            :base(options)
        {

        }

        public DbSet<Alumno> Ap_Franco_Bertol_Alumno { get; set; }
        public DbSet<Curso> Ap_Franco_Bertol_Curso { get; set; }
        public DbSet<Notas> Ap_Franco_Bertol_Notas { get; set; }
    }
}
