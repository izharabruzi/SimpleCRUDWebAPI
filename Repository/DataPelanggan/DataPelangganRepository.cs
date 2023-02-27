using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataPelangganModel;
using Dapper;
using IRepository;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace Repository
{
    public class DataPelangganRepository : IDataPelangganRepository
    {
        private string? connection;
        IConfiguration? configuration;

        public DataPelangganRepository(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("connstring");
        }

        public async Task<List<DataPelanggan>> SelectAllPelanggan()
        {
            using (var sql = new SqlConnection(connection))
            {
                var result = await sql.QueryAsync<DataPelanggan>(@"SELECT * FROM [DataPelanggan];");
                return result.ToList();
            }

        }

        public async Task InsertPelanggan(DataPelanggan model)
        {
            using (var sql = new SqlConnection(connection))
            {
                var query = @"INSERT INTO [DataPelanggan] (
              [Nama], [Kelamin], [CreatedDate], [Saldo])
              VALUES (
              @Nama,
              @Kelamin,
              @CreatedDate,
              @Saldo);";
                await sql.QueryAsync<DataPelanggan>(query, model);
            }
        }

        public async Task<bool> DeletePelanggan(DataPelanggan model)
        {
            using (var sql = new SqlConnection(connection))
            {
                var query = @" DELETE FROM [DataPelanggan] WHERE Id = @Id";
                var result = await sql.ExecuteAsync(query, model);
                return result > 0;
            }

        }

        public async Task<DataPelanggan> GetByIdPelanggan(int id)
        {
            using (var sql = new SqlConnection(connection))
            {
                var result = await sql.QueryAsync<DataPelanggan>($@"SELECT * FROM [DataPelanggan] WHERE Id = @Id;",new {id});
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> UpdatePelanggan(DataPelanggan model)
        {
            using (var sql = new SqlConnection(connection))
            {
                var query = @" UPDATE [DataPelanggan] SET
                               Nama = @Nama,
                               Kelamin = @Kelamin,
                               UpdatedDate = @UpdatedDate,
                               Saldo = @Saldo  
                               WHERE Id = @Id";
                var result = await sql.ExecuteAsync(query, model);
                return result > 0;
            }

        }
    }
}
