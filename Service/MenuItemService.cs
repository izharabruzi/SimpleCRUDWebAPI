using DataPelangganModel;
using IRepository;
using IService;
using MenuItemModel;
using Model.DataPelangganModel;
using Model.MenuItemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<List<MenuItem>> GetAllItem()
        {
            return await _menuItemRepository.SelectAllItem();
        }
        public async Task InsertBarang(MenuItemSubmitModel model)
        {
            model.Menu.CreatedBarang = DateTime.UtcNow;
            await _menuItemRepository.InsertItem(model.Menu);
        }
        public async Task DeleteBarang(int id)
        {
            var ItemData = await _menuItemRepository.GetByIdItem(id);
            await _menuItemRepository.DeleteItem(ItemData);
        }
        public async Task UpdateBarang(int id, MenuItemSubmitModel model)
        {
            model.Menu.UpdatedBarang = DateTime.UtcNow;
            await _menuItemRepository.UpdateItem(model.Menu);
        }

        public async Task<MenuItem> SelectByIdItem(int id)
        {
            var data = await _menuItemRepository.GetByIdItem(id);
            return data;
        }
    }
}
