using Model.DataPelangganModel;
using System;


namespace IRepository
{
    public interface IDataPelangganRepository
    {
        Task<List<DataPelanggan>> SelectAllPelanggan() ;
        //Task<List<DataPelanggan>> GetAllSearch(string search);
        Task InsertPelanggan(DataPelanggan model);
        Task<DataPelanggan?> GetByIdPelanggan(int id);
        Task<bool> UpdatePelanggan(DataPelanggan datapelanggan);
        Task<bool> DeletePelanggan(DataPelanggan model);
    }
}
