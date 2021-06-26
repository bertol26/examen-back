using Crud_WebApi.DTO;
using Crud_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<ProductoDto>> GetAllProducto();
        Task<ProductoDto> GetById(int id);
        Task<int> AddProducto(ProductoDto entity);
        Task<int> UpdateProducto(ProductoDto entity);
        Task<int> DeleteProducto(int id);
    }
}
