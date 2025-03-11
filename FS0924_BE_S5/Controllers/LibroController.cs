﻿using FS0924_BE_S5.Models.ViewModels;
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

        public async Task<IActionResult> Index()
        {
            var Lista = await _libroServices.GetBooks();

            return View(Lista);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(LibroAddViewModel addModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nel aggiunta del libro";
                return RedirectToAction("Index");
            }

            var isAdded = await _libroServices.AddBookAsync(addModel);
            if (!isAdded)
            {
                TempData["Error"] = "Errore nel aggiunta del libro";
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var libro = await _libroServices.GetLibro(id);

            if (libro == null)
            {
                return RedirectToAction("Index");
            }

            var editModel = new LibroEditViewModel()
            {
                Id = libro.Id,
                Titolo = libro.Titolo,
                Autore = libro.Autore,
                Genere = libro.Genere,
                Disponibilita = libro.Disponibilita,
                Copertina = libro.Copertina
            };
            return View(editModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LibroEditViewModel editViewModel)
        {
            var isEdited = await _libroServices.EditBook(editViewModel);

            if (!isEdited)
            {
                TempData["Error"] = "Errore nella modifica del Libro";
            }


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _libroServices.DeleteBook(id);
            if (!isDeleted)
            {
                TempData["Error"] = "Errore nella cancellazione del libro selezionato";
            }

            return RedirectToAction("Index");
        }





    }
}
