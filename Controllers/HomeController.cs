using Elfie.Serialization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MvcRentApp.Data;
using MvcRentApp.Models;
using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Encodings.Web;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static MvcRentApp.Controllers.HomeController;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MvcRentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly RentContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, RentContext context)
        {
            _logger = logger;
            db = context;
        }

        private void GiveOffices()
        {
            var allOffices = db.Offices.ToList<Office>();
            ViewBag.Offices = allOffices;
        }

        public IActionResult Index()
        {
            GiveOffices();
            //var allOffices = db.Offices.ToList<Office>();
            //ViewBag.Offices = allOffices;
            return View();
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
        [HttpGet]
        public ActionResult CreateBid()
        {

            GiveOffices();
            var allBids = db.Bids.ToList<Bid>();
            ViewBag.Bids = allBids;

            return View();
        }
        [HttpPost]
        public string CreateBid(Bid newBid)
        {
            newBid.bidDate = DateTime.Now;
            // Добавляем новую заявку в БД
            db.Bids.Add(newBid);
            // Сохраняем в БД все изменения
            db.SaveChanges();
            return "Спасибо, " + newBid.Name + ", за выбор нашего компании. Ваша заявка будет рассмотрена в течении 10 дней.";
        }
        public ActionResult BidSearch(string name)
        {
            var allBids = db.Bids.Where(a =>
            a.Adress.Contains(name)).ToList();
            if (allBids.Count == 0)
            {
                return Content("Указанный бизнес центр " + name + " не найден");
                //return HttpNotFound();
            }
            return PartialView(allBids);
        }
        public ActionResult OnPostSquareSearch()
        {
            var allOffices = db.Offices.OrderBy(s => s.OfficeSquare).Take(5);
            return PartialView(allOffices);
        }
        //класс для хранения суммы площади офисов
        public class OfficeSquareSum
        {
            public string BuisnessCenterAdress { get; set; }
            public double SquareSum { get; set; }
        }
        public async Task<IActionResult> SumSquare(string name)
        {
            var allOffices = db.Offices.Where(a => a.BuisnessCenterAdress.Contains(name)).ToList();
            return PartialView(allOffices);
        }

        // Выгрузка списка офисов
            [HttpGet]
        public IActionResult DownloadFile()
        {
            var allOffices = db.Offices.ToList<Office>();
            ViewBag.Offices = allOffices;
            if (allOffices == null) return NotFound();

            // 2. Настраиваем сериализатор, чтобы русские буквы не превращались в коды
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true // Красивый отступ для читаемости
            };

            // 3. Превращаем объект в JSON-строку
            string jsonString = JsonSerializer.Serialize(allOffices, options);

            // 4. Переводим строку в массив байт
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

            // 5. Отдаем файл в браузер (он автоматически попадет в папку "Загрузки")
            string fileName = "Текстовый документ.txt";
            return File(fileBytes, "application/txt", fileName);
        }
    }
}
