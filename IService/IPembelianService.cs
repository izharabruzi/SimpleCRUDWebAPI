using MenuItemModel;
using Model.MenuItemModel;
using Model.PembelianModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
    public interface IPembelianService
    {
        Task<List<Pembelian>> GetAllNamaItem();
        Task<List<Pembelian>> GetAllNamaCustomer();
        Task<List<Pembelian>> GetAllItemPembelian();
        Task<Pembelian> InsertBarangPembelian(Pembelian model);
        Task UpdateBarangPembelianMenuItem(Pembelian model);
        Task<Pembelian> SelectByIdItemPembelian(int id);

    }
}
