using FS0924_BE_S5.Services;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_BE_S5.Controllers
{
    public class LibroController : Controller
    {
        //DEPENDENCY INJECTION DEL SERVICE
        private readonly LibroServices _libroServices;
        public LibroController(LibroServices services)
        {
            _libroServices = services;
        }

        public IActionResult Index()
        {
            var Lista = _libroServices.GetBooks();

            return View(Lista);
        }
    }
}
