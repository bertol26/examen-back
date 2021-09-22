using Crud_WebApi.DTO;
using Crud_WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crud_WebApi.Controllers
{
    [Route("api/Producto")]
    [Produces("application/json")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        // GET: api/<ProductoController>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProductoDto>> GetAll()
        {
            return await _productoService.GetAllProducto();
        }

        // GET api/<ProductoController>/5
        [HttpGet("GetById/{id}")]
        public async Task<ProductoDto> GetById(int id)
        {
            return await _productoService.GetById(id);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult> Create(ProductoDto producto)
        {
            var result = await _productoService.AddProducto(producto);
            if (result == 1) return Ok(); else return NotFound(); 
        }

        // PUT api/<ProductoController>/5
        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] ProductoDto producto)
        {
            var result = await _productoService.UpdateProducto(producto);
            if (result == 1) return Ok(); else return NotFound();
            
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productoService.DeleteProducto(id);
            if (result == 1) return Ok(); else return NotFound();
        }
    }
}
