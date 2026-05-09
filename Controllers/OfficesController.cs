using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using MvcRentApp.Data;
using MvcRentApp.Models;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MvcRentApp.Controllers
{
    public class OfficesController : Controller
    {
        private readonly RentContext _context;

        public OfficesController(RentContext context)
        {
            _context = context;
        }

        // GET: Offices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Offices.ToListAsync());
        }

        // GET: Offices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _context.Offices
                .FirstOrDefaultAsync(m => m.OfficeId == id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        // GET: Offices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfficeId,BuisnessCenterAdress,BuisnessCenterFloor,OfficeNumber,OfficeSquare,RentalRate,OfficeState,OfficeLayout")] Office office)
        {
            if (ModelState.IsValid)
            {
                _context.Add(office);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Offices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _context.Offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);
        }

        // POST: Offices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfficeId,BuisnessCenterAdress,BuisnessCenterFloor,OfficeNumber,OfficeSquare,RentalRate,OfficeState,OfficeLayout")] Office office)
        {
            if (id != office.OfficeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(office);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeExists(office.OfficeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Offices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _context.Offices
                .FirstOrDefaultAsync(m => m.OfficeId == id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        // POST: Offices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var office = await _context.Offices.FindAsync(id);
            if (office != null)
            {
                _context.Offices.Remove(office);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeExists(int id)
        {
            return _context.Offices.Any(e => e.OfficeId == id);
        }

        //[HttpGet]
        //public IActionResult Upload()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Upload([FromForm] IFormFile file)
        //{
        // Вариант загрузки 1
        //if (file == null || file.Length == 0)
        //{
        //    return Content("файл не выбран");
        //}
        //var path = Path.Combine(Directory.GetCurrentDirectory(), "image", file.FileName);
        //using (var stream = new FileStream(path, FileMode.Create))
        //{
        //     await file.CopyToAsync(stream);
        //}
        //return RedirectToAction("Index");
        // Вариант загрузки 2
        //var filePath = Path.GetTempFileName();
        //using (var stream = System.IO.File.Create(filePath))
        //{
        //    await file.CopyToAsync(stream);
        //}
        //return Ok(new { file.Length, file.FileName });
        //}
    }
}   
