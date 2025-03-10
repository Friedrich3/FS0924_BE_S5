using FS0924_BE_S5.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S5.Data

{
    public class PraticaBES5 : DbContext
    {
        //QUESTO SERVE PER CREARE UN NUOVO DATABASE A PARTIRE DALLA CLASSE DBCONTEXT
        //E PER PASSARE LA STRINGA DI CONNESSIONE CHE ANDREMO A SPECIFICARE NEL PROGRAM ALLA CLASSE BASE DBCONTEXT
        public PraticaBES5(DbContextOptions<PraticaBES5> options) : base(options) { }

        //DOPO IL COSTRUTTORE VERRANNO INSERITI I VARI DBSET per le tabelle del DATABASE
        //OGNI DbSet Necessita del proprio modello e di un nome
        public DbSet<Libro> Libri { get; set; }
    }
}
