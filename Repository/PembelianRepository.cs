using Dapper;
using IRepository;
using Microsoft.Extensions.Configuration;
using Model.MenuItemModel;
using Model.PembelianModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PembelianRepository : IPembelianRepository
    {
        private string? connection;
        IConfiguration? configuration;

        public PembelianRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("connstring");
        }

        public async Task<List<Pembelian>> SelectAllNamaItem()
        {
            using (var sql = new SqlConnection(connection))
            {
                var result = await sql.QueryAsync<Pembelian>(@"SELECT * FROM [MenuItem];");
                return result.ToList();
            }

        }

        public async Task<List<Pembelian>> SelectAllPembelian()
        {
            using (var sql = new SqlConnection(connection))
            {
                var result = await sql.QueryAsync<Pembelian>(@"SELECT * FROM [Orders];");
                return result.ToList();
            }

        }

        public async Task<List<Pembelian>> SelectAllNamaCustomer()
        {
            using (var sql = new SqlConnection(connection))
            {
                var result = await sql.QueryAsync<Pembelian>(@"SELECT * FROM [DataPelanggan];");
                return result.ToList();
            }

        }

        public async Task<Pembelian> GetByIdItemPembelian(int id)
        {
            using (var sql = new SqlConnection(connection))
            {
                var result = await sql.QueryAsync<Pembelian>($@"SELECT * FROM 
                            [Orders]
                            JOIN [DataPelanggan] ON DataPelanggan.Id= Orders.CustomerId
                            WHERE [CustomerId] = @id", new { id });
                return result.LastOrDefault();
            }
        }

        public async Task<bool> InsertPembelian(Pembelian model)
        {
            using (var sql = new SqlConnection(connection))
            {
                var query = @"
                            INSERT INTO [Orders] (
                            [OrderDate], [CustomerId])
                            VALUES (
                            @OrderDate,
                            @CustomerId);";
                var result = await sql.ExecuteAsync(query, model);
                return result > 0;
            }

        }



        //public async Task<bool> UpdatePembelianMenuItem(Pembelian model)
        //{
        //    using (var sql = new SqlConnection(connection))
        //    {
        //        var query = @"
        //                 UPDATE [Orders]
        //                    SET [CustomerId] = @CustomerId
        //                 WHERE OrderId = @OrderId;";
        //        var result = await sql.ExecuteAsync(query, model);
        //        return result > 0;
        //    }

        //}

        public async Task<bool> UpdatePembelianMenuItem(Pembelian model)
        {
            using (var sql = new SqlConnection(connection))
            {
                var query = @"
                        SELECT * FROM 
                        [Orders]
                        JOIN [MenuItem] ON MenuItem.IdOrder = Orders.OrderId
                        UPDATE [MenuItem] 
                            SET [IdOrder] = @OrderId
                            WHERE IdBarang = @IdBarang;";
                var result = await sql.ExecuteAsync(query, model);
                return result > 0;
            }

        }

    }
}
