using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.DTO
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int Stock { get; set; }
        public string FechaRegistro { get; set; }
    }

    public class ProductValidator : AbstractValidator<ProductoDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.Precio).NotEmpty();
            RuleFor(x => x.Stock).InclusiveBetween(0,50);
        }
    }
}
