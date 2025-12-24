using Microsoft.AspNetCore.Mvc;
using GudangWebApp.Models;
using GudangWebApp.ViewModels;

namespace GudangWebApp.Controllers
{
    public class BarangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ - Index
        public IActionResult Index()
        {
            var data = _context.Barang.ToList();
            return View(data);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BarangViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Mapping ViewModel ke Entity
                var barang = new Barang
                {
                    KodeBarang = viewModel.KodeBarang,
                    NamaBarang = viewModel.NamaBarang,
                    JumlahStok = viewModel.JumlahStok,
                    Kategori = viewModel.Kategori
                };

                _context.Barang.Add(barang);
                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            
            // Jika validasi gagal, tampilkan form lagi dengan error
            return View(viewModel);
        }

        // EDIT - GET
        public IActionResult Edit(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null)
            {
                return NotFound();
            }

            // Mapping Entity ke ViewModel
            var viewModel = new BarangViewModel
            {
                Id = barang.Id,
                KodeBarang = barang.KodeBarang,
                NamaBarang = barang.NamaBarang,
                JumlahStok = barang.JumlahStok,
                Kategori = barang.Kategori
            };

            return View(viewModel);
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BarangViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Mapping ViewModel ke Entity
                var barang = new Barang
                {
                    Id = viewModel.Id,
                    KodeBarang = viewModel.KodeBarang,
                    NamaBarang = viewModel.NamaBarang,
                    JumlahStok = viewModel.JumlahStok,
                    Kategori = viewModel.Kategori
                };

                _context.Barang.Update(barang);
                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            
            // Jika validasi gagal, tampilkan form lagi dengan error
            return View(viewModel);
        }

        // DELETE - GET (Confirmation Page)
        public IActionResult Delete(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null)
            {
                return NotFound();
            }
            return View(barang);
        }

        // DELETE - POST (Actual Delete)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang != null)
            {
                _context.Barang.Remove(barang);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
