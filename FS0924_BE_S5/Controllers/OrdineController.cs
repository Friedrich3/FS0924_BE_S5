using FS0924_BE_S5.Services;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_BE_S5.Controllers
{
    public class OrdineController : Controller
    {
        private readonly OrdineServices _ordineServices;
        public OrdineController(OrdineServices services)
        {
            _ordineServices = services;
        }



        public async Task<IActionResult> Index()
        {
            var Lista = await _ordineServices.GetBooksDisp();
            return View(Lista);
        }

        public async Task<IActionResult> NewOrder(Guid id)
        {
            var isAdded = await _ordineServices.AddOrder(id);
            if (!isAdded)
            {
                TempData["Error"] = "Errore nel aggiunta del libro";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> InCorso()
        {
            var Lista = await _ordineServices.GetInCorso();
            return View(Lista);
        }

        public async Task<IActionResult> ConsegnaLibro()
        {



            return RedirectToAction("InCorso");
        }
    }
}
