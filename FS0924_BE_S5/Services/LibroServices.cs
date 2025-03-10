using FS0924_BE_S5.Data;
using FS0924_BE_S5.Models;
using FS0924_BE_S5.Models.ViewModels;

namespace FS0924_BE_S5.Services
{
    public class LibroServices
    {
        private readonly PraticaBES5 _context;
        public LibroServices(PraticaBES5 context)
        {
            _context = context;
        }

        public ListaLibriViewModel GetBooks() 
        {
            //andiamo a Dichiarare una nuova lista dei libri e dentro ci andiamo a mettere il contenuto
            //del db ( _context ) ed a quale tabella fa riferimento ( .Libri ) ed un metodo su come trattare i dati
            try 
            {
                var ListaLibri = new ListaLibriViewModel();
                    ListaLibri.Libri = _context.Libri.ToList();
                return ListaLibri;
            }
            //Nel Caso non trovi nulla nella tabella di riferimento torna una lista vuota
            //QUindi andiamo a creare un nuova istanza del viewModel che a sua volta crea una istanza di una lista ma vuota
            catch
            {
                return new ListaLibriViewModel() { Libri = new List<Libro>() };
            }
        }
        

    }
}
