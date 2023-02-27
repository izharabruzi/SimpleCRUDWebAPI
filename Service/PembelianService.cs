using IRepository;
using IService;
using MenuItemModel;
using Model.MenuItemModel;
using Model.PembelianModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PembelianService : IPembelianService
    {
        private readonly IPembelianRepository _pembelianRepository;
        public PembelianService(IPembelianRepository pembelianRepository)
        {
            _pembelianRepository = pembelianRepository;
        }
        public async Task<List<Pembelian>> GetAllNamaItem()
        {
            return await _pembelianRepository.SelectAllNamaItem();
        }
        public async Task<List<Pembelian>> GetAllNamaCustomer()
        {
            return await _pembelianRepository.SelectAllNamaCustomer();
        }

        public async Task<List<Pembelian>> GetAllItemPembelian()
        {
            return await _pembelianRepository.SelectAllPembelian();
        }
        public async Task<Pembelian> SelectByIdItemPembelian(int id)
        {
            var data = await _pembelianRepository.GetByIdItemPembelian(id);
            return data;
        }
        public async Task<Pembelian> InsertBarangPembelian(Pembelian model)
        {
            model.OrderDate = DateTime.UtcNow;
            await _pembelianRepository.InsertPembelian(model);
            return model;
        }

        public async Task UpdateBarangPembelianMenuItem(Pembelian model)
        {
            await _pembelianRepository.UpdatePembelianMenuItem(model);
        }
    }
}
