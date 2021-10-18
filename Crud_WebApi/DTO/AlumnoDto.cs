using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.DTO
{
    public class AlumnoDto
    {
        public int? Id { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }
}
