using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FS0924_BE_S5.Models
{
    public class Genere
    {
        [Key]
        public int IdGenere { get; set;}
        [Required]
        public string? Name { get; set; }


        public List<Libro> LibriGenere {  get; set; }
    }
}
