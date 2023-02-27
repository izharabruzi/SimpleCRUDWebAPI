using DataPelangganModel;
using IService;
using MenuItemModel;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMenuPelanggan.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly ILogger<MenuItemController> _logger;
        IMenuItemService _menuItemService;
        public MenuItemController(ILogger<MenuItemController> logger, IMenuItemService menuItemService)
        {
            _logger = logger;
            _menuItemService = menuItemService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MenuItem()
        {
            var result = await _menuItemService.GetAllItem();
            return View(result);
        }

        ////[HttpPost]

        public IActionResult CreateMenuItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatedMenuItem(MenuItemSubmitModel model)
        {
            await _menuItemService.InsertBarang(model);
            TempData["SuccessMessage"] = "Customer added successfully.";
            return RedirectToAction("MenuItem", "MenuItem");
            //return Ok("Customer Berhasil Ditambahkan!");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _menuItemService.DeleteBarang(id);
            return RedirectToAction("MenuItem", "MenuItem");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMenuItem(int id)
        {
            var model = await _menuItemService.SelectByIdItem(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatedMenuItem(int id, MenuItemSubmitModel model)
        {
            await _menuItemService.UpdateBarang(id, model);
            return RedirectToAction("MenuItem", "MenuItem");
        }
    }
}
