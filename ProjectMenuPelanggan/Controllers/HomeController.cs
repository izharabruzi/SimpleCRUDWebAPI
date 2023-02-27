using DataPelangganModel;
using IRepository;
using IService;
using Microsoft.AspNetCore.Mvc;
using Model.DataPelangganModel;
using ProjectMenuPelanggan.Models;
using System.Diagnostics;
using System.Transactions;

namespace ProjectMenuPelanggan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IDataPelangganService _dataPelangganService;
        public HomeController(ILogger<HomeController> logger, IDataPelangganService dataPelangganService)
        {
            _logger = logger;
            _dataPelangganService = dataPelangganService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Customer()
        {
            var result = await _dataPelangganService.GetAllPelanggan();
            return View(result);
        }

        ////[HttpPost]

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatedCustomer(DataPelangganSubmitModel model)
        {
            await _dataPelangganService.Insert(model);
            TempData["SuccessMessage"] = "Customer added successfully.";

            return RedirectToAction("Customer", "Home");
            //return Ok("Customer Berhasil Ditambahkan!");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _dataPelangganService.Delete(id);
            return RedirectToAction("Customer", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var model = await _dataPelangganService.SelectById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatedCustomer( int id, DataPelangganSubmitModel model)
        {
            await _dataPelangganService.Update(id, model);
            return RedirectToAction("Customer", "Home");
        }

        




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpGet]
        //public async Task<List<DataPelanggan>> Get()
        //{
        //    var result = await _dataPelangganService.GetAllPelanggan();
        //    return result;

        //}
    }
}