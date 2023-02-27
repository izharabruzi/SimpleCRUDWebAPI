using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataPelangganModel;
using Model.MenuItemModel;

namespace IRepository
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> SelectAllItem();
        //Task<List<DataPelanggan>> GetAllSearch(string search);
        Task InsertItem(MenuItem model);
        Task<MenuItem?> GetByIdItem(int id);
        Task<bool> UpdateItem(MenuItem model);
        Task<bool> DeleteItem(MenuItem model);

    }
}
