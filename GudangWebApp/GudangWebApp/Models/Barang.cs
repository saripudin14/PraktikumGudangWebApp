using System.ComponentModel.DataAnnotations;

namespace GudangWebApp.Models
{
    public class Barang
    {
        public int Id { get; set; }

        [Required]
        public string KodeBarang { get; set; }

        [Required]
        public string NamaBarang { get; set; }

        [Range(0, int.MaxValue)]
        public int JumlahStok { get; set; }

        public string Kategori { get; set; }
    }
}
