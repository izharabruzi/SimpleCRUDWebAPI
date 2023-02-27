using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPelangganModel;
using IRepository;
using IService;
using Model.DataPelangganModel;
using Repository;
using Service;
namespace Service
{
    public class DataPelangganService : IDataPelangganService
    {
        private readonly IDataPelangganRepository _dataPelangganRepository;
        public DataPelangganService(IDataPelangganRepository dataPelangganRepository)
        {
            _dataPelangganRepository = dataPelangganRepository;
        }

        public async Task<List<DataPelanggan>> GetAllPelanggan()
        {
            return await _dataPelangganRepository.SelectAllPelanggan();
        }
        public async Task Insert(DataPelangganSubmitModel model)
        {
            model.Pelanggan.CreatedDate = DateTime.UtcNow;
            await _dataPelangganRepository.InsertPelanggan(model.Pelanggan);
        }
        public async Task Delete(int id)
        {
            var PelangganData = await _dataPelangganRepository.GetByIdPelanggan(id);
            await _dataPelangganRepository.DeletePelanggan(PelangganData);
        }
        public async Task Update(int id, DataPelangganSubmitModel model)
        {
            model.Pelanggan.UpdatedDate = DateTime.UtcNow;
            await _dataPelangganRepository.UpdatePelanggan(model.Pelanggan);
        }

        public async Task<DataPelanggan> SelectById(int id)
        {
            var data = await _dataPelangganRepository.GetByIdPelanggan(id);
            return data;
        }
    }
}
