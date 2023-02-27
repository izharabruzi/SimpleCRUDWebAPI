using Model.MenuItemModel;
using Model.PembelianModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IPembelianRepository
    {
        Task<List<Pembelian>> SelectAllNamaItem();
        Task<List<Pembelian>> SelectAllNamaCustomer();
        Task<List<Pembelian>> SelectAllPembelian();

        Task<bool> InsertPembelian(Pembelian model);
        Task<bool> UpdatePembelianMenuItem(Pembelian model);

        Task<Pembelian> GetByIdItemPembelian(int id);

    }
}
