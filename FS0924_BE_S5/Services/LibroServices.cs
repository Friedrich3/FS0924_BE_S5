using FS0924_BE_S5.Data;
using FS0924_BE_S5.Models;
using FS0924_BE_S5.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S5.Services
{
    public class LibroServices
    {
        private readonly PraticaBES5 _context;
        public LibroServices(PraticaBES5 context)
        {
            _context = context;
        }

        private async Task<bool> SaveChange() 
        {
            try
            {
                var righe = await _context.SaveChangesAsync();
                if(righe > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
            return false;   
            }
        }


        public async Task<ListaLibriViewModel> GetBooks() 
        {
            //andiamo a Dichiarare una nuova lista dei libri e dentro ci andiamo a mettere il contenuto
            //del db ( _context ) ed a quale tabella fa riferimento ( .Libri ) ed un metodo su come trattare i dati
            try 
            {
                var ListaLibri = new ListaLibriViewModel();
                ListaLibri.Libri = await _context.Libri.ToListAsync();
                return ListaLibri;
            }
            //Nel Caso non trovi nulla nella tabella di riferimento torna una lista vuota
            //QUindi andiamo a creare un nuova istanza del viewModel che a sua volta crea una istanza di una lista ma vuota
            catch
            {
                return new ListaLibriViewModel() { Libri = new List<Libro>() };
            }
        }

        public async Task<bool> AddBookAsync(LibroAddViewModel addmodel) 
        {
            var book = new Libro()
            {
                Id = Guid.NewGuid(),
                Titolo = addmodel.Titolo,
                Autore = addmodel.Autore,
                Genere = addmodel.Genere,
                Disponibilita = addmodel.Disponibilita,
                Copertina = addmodel.Copertina
            };
            _context.Libri.Add(book);


            return await SaveChange();
        }

        public async Task<Libro?> GetLibro(Guid id)
        {
            //FindAsync() con un parametro ritorna quell oggetto a cui stiamo accedendo
            var libro = await _context.Libri.FindAsync(id);
            if(libro == null)
            {
                return null;
            }

            return libro;

        }

        public async Task<bool> EditBook(LibroEditViewModel editViewModel)
        {
            var libro = await _context.Libri.FindAsync(editViewModel.Id);
            if (libro == null)
            {
                return false;
            }
            libro.Titolo = editViewModel.Titolo;
            libro.Autore = editViewModel.Autore;
            libro.Genere = editViewModel.Genere;
            libro.Disponibilita = editViewModel.Disponibilita;
            libro.Copertina = editViewModel.Copertina;

            return await SaveChange();
        }


        public async Task<bool> DeleteBook (Guid id)
        {
            var libro = await _context.Libri.FindAsync(id);
            if (libro == null)
            {
                return false;
            }
            _context.Libri.Remove(libro);
            return await SaveChange();
        }



    }
}
