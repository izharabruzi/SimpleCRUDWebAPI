using DataPelangganModel;
using MenuItemModel;
using Model.DataPelangganModel;
using Model.MenuItemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IService
{
     public interface IMenuItemService
    {
        Task<List<MenuItem>> GetAllItem();
        Task InsertBarang(MenuItemSubmitModel model);
        Task DeleteBarang(int id);
        Task UpdateBarang(int id, MenuItemSubmitModel model);
        Task<MenuItem> SelectByIdItem(int id);
    }
}
