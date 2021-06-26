using Crud_WebApi.DTO;
using Crud_WebApi.Repositories.Interfaces;
using Crud_WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Services.Services
{
    public class ProductoService: IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<int> AddProducto(ProductoDto entity)
        {
            return await _productoRepository.AddProducto(entity);
        }

        public async Task<int> DeleteProducto(int id)
        {
            return await _productoRepository.DeleteProducto(id);
        }

        public async Task<IEnumerable<ProductoDto>> GetAllProducto()
        {
            return await _productoRepository.GetAllProducto();
        }

        public async Task<ProductoDto> GetById(int id)
        {
            return await _productoRepository.GetById(id);
        }

        public async Task<int> UpdateProducto(ProductoDto entity)
        {
            return await _productoRepository.UpdateProducto(entity);
        }
    }
}
