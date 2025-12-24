using Microsoft.AspNetCore.Mvc;
using GudangWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GudangWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarangApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarangApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/barangapi
        // Mengambil semua data barang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barang>>> GetAllBarang()
        {
            var barangList = await _context.Barang.ToListAsync();
            return Ok(barangList);
        }

        // GET: api/barangapi/{id}
        // Mengambil data barang berdasarkan ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Barang>> GetBarangById(int id)
        {
            var barang = await _context.Barang.FindAsync(id);

            if (barang == null)
            {
                return NotFound(new { message = $"Barang dengan ID {id} tidak ditemukan" });
            }

            return Ok(barang);
        }

        // POST: api/barangapi
        // Menambahkan data barang baru
        [HttpPost]
        public async Task<ActionResult<Barang>> CreateBarang([FromBody] Barang barang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Barang.Add(barang);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBarangById),
                new { id = barang.Id },
                barang
            );
        }

        // PUT: api/barangapi/{id}
        // Mengupdate data barang berdasarkan ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarang(int id, [FromBody] Barang barang)
        {
            if (id != barang.Id)
            {
                return BadRequest(new { message = "ID tidak cocok" });
            }

            var existingBarang = await _context.Barang.FindAsync(id);
            if (existingBarang == null)
            {
                return NotFound(new { message = $"Barang dengan ID {id} tidak ditemukan" });
            }

            // Update properties
            existingBarang.KodeBarang = barang.KodeBarang;
            existingBarang.NamaBarang = barang.NamaBarang;
            existingBarang.JumlahStok = barang.JumlahStok;
            existingBarang.Kategori = barang.Kategori;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, new { message = "Error saat update data" });
            }

            return NoContent();
        }

        // DELETE: api/barangapi/{id}
        // Menghapus data barang berdasarkan ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarang(int id)
        {
            var barang = await _context.Barang.FindAsync(id);

            if (barang == null)
            {
                return NotFound(new { message = $"Barang dengan ID {id} tidak ditemukan" });
            }

            _context.Barang.Remove(barang);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Barang berhasil dihapus", data = barang });
        }
    }
}
