using System.ComponentModel.DataAnnotations;

namespace FS0924_BE_S5.Models.ViewModels
{
    public class LibroAddViewModel
    {
        [Required]
        [StringLength(100)]
        public string? Titolo { get; set; }
        [Required]
        [StringLength(50)]
        public string? Autore { get; set; }
        [Required]
        public int IdGenere { get; set; }
        public bool Disponibilita { get; set; }
        public IFormFile? Copertina { get; set; }
    }
}
