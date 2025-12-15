using Microsoft.AspNetCore.Mvc;
using GudangWebApp.Models;

namespace GudangWebApp.Controllers
{
    public class BarangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarangController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Barang.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Barang barang)
        {
            if (ModelState.IsValid)
            {
                _context.Barang.Add(barang);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barang);
        }

        public IActionResult Edit(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null)
            {
                return NotFound();
            }
            return View(barang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Barang barang)
        {
            if (ModelState.IsValid)
            {
                _context.Barang.Update(barang);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barang);
        }

        public IActionResult Delete(int id)
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
