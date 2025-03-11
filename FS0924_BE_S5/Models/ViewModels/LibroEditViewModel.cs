using System.ComponentModel.DataAnnotations;

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
        [StringLength(50)]
        public string? Genere { get; set; }
        public bool Disponibilita { get; set; }
        public string? Copertina { get; set; }
    }
}
