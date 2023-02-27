using IService;
using Model.PembelianModel;
using Microsoft.AspNetCore.Mvc;
using Service;
using Microsoft.AspNetCore.Components.Forms;

namespace ProjectMenuPelanggan.Controllers
{
    public class MenuPembelianController : Controller
    {
        private readonly ILogger<MenuPembelianController> _logger;
        IMenuItemService _menuItemService;
        IPembelianService _pembelianService;
        public MenuPembelianController(ILogger<MenuPembelianController> logger, IMenuItemService menuItemService
           , IPembelianService pembelianService)
        {
            _logger = logger;
            _menuItemService = menuItemService;
            _pembelianService = pembelianService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> Pembelian()
        //{
        //    var result = await _menuItemService.GetAllItem();
        //    return View(result);
        //}
        public async Task<IActionResult> Pembelian(Pembelian model)
        {
            var barangitem = await _pembelianService.GetAllNamaItem();
            var customer = await _pembelianService.GetAllNamaCustomer();
            var pembelian = await _pembelianService.GetAllItemPembelian();
            return View((barangitem, customer, pembelian));
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPembelian(Pembelian model, int id)
        {
            model.OrderId = id;
            await _pembelianService.InsertBarangPembelian(model);
            return RedirectToAction("Pembelian", "MenuPembelian");
            //return Redirect(redirectUrl + "?orderId=" + model.OrderId + "&namaBarang=" + model.NamaBarang + "&hargaBarang=" + model.HargaBarang + "&idBarang=" + model.IdBarang);
        }






        [HttpPost("id")]
        public async Task<IActionResult> UpdateMenuItemBarang(Pembelian model, int id)
        {
            if (model == null)
            {
                model = new Pembelian();
            }
            //model2.OrderId = model3.CustomerId;
            model.OrderId = id;
            await _pembelianService.UpdateBarangPembelianMenuItem(model);
            return RedirectToAction("Customer", "Home");
        } 


        //    [HttpGet]
        //    public async Task<IActionResult> MenuItem()
        //    {
        //        var result = await _menuItemService.GetAllItem();
        //        return View(result);
        //    }

        //    ////[HttpPost]

        //    public IActionResult CreateMenuItem()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> CreatedMenuItem(MenuItemSubmitModel model)
        //    {
        //        await _menuItemService.InsertBarang(model);
        //        TempData["SuccessMessage"] = "Customer added successfully.";
        //        return RedirectToAction("MenuItem", "MenuItem");
        //        //return Ok("Customer Berhasil Ditambahkan!");
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> DeleteMenuItem(int id)
        //    {
        //        await _menuItemService.DeleteBarang(id);
        //        return RedirectToAction("MenuItem", "MenuItem");
        //    }

        //    [HttpGet]
        //    public async Task<IActionResult> UpdateMenuItem(int id)
        //    {
        //        var model = await _menuItemService.SelectByIdItem(id);
        //        return View(model);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> UpdatedMenuItem(int id, MenuItemSubmitModel model)
        //    {
        //        await _menuItemService.UpdateBarang(id, model);
        //        return RedirectToAction("MenuItem", "MenuItem");
        //    }
        //}
    }
}
