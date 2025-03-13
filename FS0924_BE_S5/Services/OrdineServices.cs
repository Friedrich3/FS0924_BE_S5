using FS0924_BE_S5.Data;
using FS0924_BE_S5.Models;
using FS0924_BE_S5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FS0924_BE_S5.Services
{
    public class OrdineServices
    {
        private readonly PraticaBES5 _context;
        public OrdineServices(PraticaBES5 context)
        {
            _context = context;
        }

        private async Task<bool> SaveChange()
        {
            try
            {
                var righe = await _context.SaveChangesAsync();
                if (righe > 0)
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


        public async Task<ListaLibriViewModel> GetBooksDisp()
        {
            var Lista = new ListaLibriViewModel();
            Lista.Libri = await _context.Libri.Include(i => i.Genere).Where(d => d.Disponibilita.Equals(true)).ToListAsync();
            return Lista;
        }

    public async Task<bool> AddOrder(Guid id)
        {
            try
            {
            var user = _context.Utenti.FirstOrDefault();
            var libro = await _context.Libri.FindAsync(id);
            var ordine = new Ordine()
            {
                LibroId = id,
                UtenteId = user.IdUtente,
                Stato = "pending"

            };
            _context.Ordini.Add(ordine);

             libro!.Disponibilita = false;
            
            return await SaveChange();

            }
            catch (Exception)
            {

                throw;
            }
        }


    public async Task<ListaLibriViewModel> GetInCorso()
        {
            var Lista = new ListaLibriViewModel();
            Lista.Libri = await _context.Libri.Include(i => i.Genere).Where(d => d.Disponibilita.Equals(false)).ToListAsync();
            return Lista;
        }

    }
}
