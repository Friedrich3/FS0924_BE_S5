using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS0924_BE_S5.Models
{
    public class Utente
    {
        [Key]
        public Guid IdUtente { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Cognome { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [ForeignKey("IdUtente")]
        public List<Ordine>? Orders { get; set; }
        
    }
}
