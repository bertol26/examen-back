using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.DTO
{
    public class CursoDto
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public bool Obligatoriedad { get; set; }
    }
}
