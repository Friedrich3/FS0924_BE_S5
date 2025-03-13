using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS0924_BE_S5.Models
{
    public class Ordine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required Guid LibroId { get; set; }
        [Required]
        public required Guid UtenteId { get; set; }
        [Required]
        [AllowedValues("pending" , "returned" ,"expired" )]
        public required string Stato { get; set; }

        //AGGIUNTO POST DEBRIEF
        [ForeignKey("LibroId")]
        public Libro? Book { get; set; }

        [ForeignKey("UtenteId")]
        public Utente? User { get; set; }

        //Day4
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInizio { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataScadenza { get; set; } = DateTime.Now.AddDays(10);
    }
}
