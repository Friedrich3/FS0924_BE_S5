using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS0924_BE_S5.Models.ViewModels
{
    public class LibroEditViewModel
    {
        public required Guid Id { get; set; }
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

        public string? StringaCopertina { get; set; }
    }
}
