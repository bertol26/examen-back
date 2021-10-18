using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Models
{
    public class Notas
    {
        [Key]
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public int IdAlumno { get; set; }
        public double Practica1 { get; set; }
        public double Practica2 { get; set; }
        public double Practica3 { get; set; }
        public double Parcial { get; set; }
        public double Final { get; set; }
        public double PromedioFinal { get; set; }
    }
}
