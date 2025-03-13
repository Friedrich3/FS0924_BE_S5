using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS0924_BE_S5.Models
{
    public class Libro
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Titolo { get; set; }
        [Required]
        [StringLength(50)]
        public string? Autore { get; set; }
        [Required]
        public int IdGenere { get; set; }

        public bool Disponibilita { get; set;}

        public string? Copertina { get; set; }

        [ForeignKey("IdGenere")]
        public Genere? Genere { get; set; }

        public List<Ordine>? Orders { get; set; }
    }
}
