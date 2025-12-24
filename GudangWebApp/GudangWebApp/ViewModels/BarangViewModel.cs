using System.ComponentModel.DataAnnotations;

namespace GudangWebApp.ViewModels
{
    public class BarangViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kode Barang wajib diisi")]
        [Display(Name = "Kode Barang")]
        public string KodeBarang { get; set; }

        [Required(ErrorMessage = "Nama Barang wajib diisi")]
        [Display(Name = "Nama Barang")]
        public string NamaBarang { get; set; }

        [Required(ErrorMessage = "Jumlah Stok wajib diisi")]
        [Range(0, int.MaxValue, ErrorMessage = "Jumlah Stok tidak boleh negatif")]
        [Display(Name = "Jumlah Stok")]
        public int JumlahStok { get; set; }

        [Display(Name = "Kategori")]
        public string? Kategori { get; set; }
    }
}
