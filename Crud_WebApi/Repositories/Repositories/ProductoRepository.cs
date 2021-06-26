using Crud_WebApi.DTO;
using Crud_WebApi.Models;
using Crud_WebApi.Repositories.Interfaces;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_WebApi.Repositories.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _cn;
        public ProductoRepository()
        {
            _cn = "Data Source=DESKTOP-FIG8HS8\\SQLEXPRESS;Initial Catalog=Prueba;Integrated Security=True";
        }
        public async Task<int> AddProducto(ProductoDto entity)
        {
            int rowAffected = 0;
            string msg = "";

            using var connection = new SqlConnection(_cn);
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", entity.Nombre);
            parameters.Add("@Precio", entity.Precio);
            parameters.Add("@Stock", entity.Stock);
            parameters.Add("@FechaRegistro", entity.FechaRegistro);

            rowAffected = await connection.ExecuteAsync("InsertProducto", parameters,
                commandType: CommandType.StoredProcedure);
            return rowAffected;
        }

        public async Task<int> DeleteProducto(int id)
        {
            int rowAffected = 0;
            string msg = "";

            using var connection = new SqlConnection(_cn);
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            rowAffected = await connection.ExecuteAsync("DeleteProducto", parameters,
                commandType: CommandType.StoredProcedure);
            return rowAffected;
        }

        public async Task<IEnumerable<ProductoDto>> GetAllProducto()
        {
            using var connection = new SqlConnection(_cn);
            var parameters = new DynamicParameters();

            var value = await connection.QueryAsync<ProductoDto>("LstProducto",
                commandType: CommandType.StoredProcedure);

            return value;
        }

        public async Task<ProductoDto> GetById(int id)
        {
            using var connection = new SqlConnection(_cn);
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var value = await connection.QueryFirstAsync<ProductoDto>("LstProductoById", parameters,
                commandType: CommandType.StoredProcedure);

            return value;
        }

        public async Task<int> UpdateProducto(ProductoDto entity)
        {
            int rowAffected = 0;
            string msg = "";

            using var connection = new SqlConnection(_cn);
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", entity.Nombre);
            parameters.Add("@Precio", entity.Precio);
            parameters.Add("@Stock", entity.Stock);
            parameters.Add("@FechaRegistro", entity.FechaRegistro);
            parameters.Add("@Id", entity.Id);

            rowAffected = await connection.ExecuteAsync("UpdProducto", parameters,
                commandType: CommandType.StoredProcedure);

            return rowAffected;
        }



    }
}
