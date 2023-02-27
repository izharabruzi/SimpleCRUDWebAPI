using Dapper;
using IRepository;
using Microsoft.Extensions.Configuration;
using Model.DataPelangganModel;
using Model.MenuItemModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private string? connection;
        IConfiguration? configuration;

        public MenuItemRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("connstring");
        }

        public async Task<List<MenuItem>> SelectAllItem()
        {
            using (var sql = new SqlConnection(connection))
            {
                var result = await sql.QueryAsync<MenuItem>(@"SELECT * FROM [MenuItem];");
                return result.ToList();
            }

        }

        public async Task InsertItem(MenuItem model)
        {
            using (var sql = new SqlConnection(connection))
            {
                var query = @"INSERT INTO [MenuItem] (
              [NamaBarang], [JumlahBarang], [HargaBarang], [CreatedBarang])
              VALUES (
              @NamaBarang,
              @JumlahBarang,
              @HargaBarang,
              @CreatedBarang);";
                await sql.QueryAsync<MenuItem>(query, model);
            }
        }

        public async Task<bool> DeleteItem(MenuItem model)
        {
            using (var sql = new SqlConnection(connection))
            {
                var query = @" DELETE FROM [MenuItem] WHERE IdBarang = @IdBarang";
                var result = await sql.ExecuteAsync(query, model);
                return result > 0;
            }

        }

        public async Task<MenuItem> GetByIdItem(int id)
        {
            using (var sql = new SqlConnection(connection))
            {
                var result = await sql.QueryAsync<MenuItem>($@"SELECT * FROM [MenuItem] WHERE IdBarang = @id;", new {id});
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateItem(MenuItem model)
        {
            using (var sql = new SqlConnection(connection))
            {
                var query = @" UPDATE [MenuItem] SET
                               NamaBarang = @NamaBarang,
                               JumlahBarang = @JumlahBarang,
                               HargaBarang = @HargaBarang,
                               UpdatedBarang = @UpdatedBarang
                               WHERE IdBarang = @IdBarang";
                var result = await sql.ExecuteAsync(query, model);
                return result > 0;
            }

        }
    }
}
