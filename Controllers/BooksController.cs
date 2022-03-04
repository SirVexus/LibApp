using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Authorization;
using LibApp.Interfaces;
>>>>>>> Stashed changes

namespace LibApp.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
<<<<<<< Updated upstream
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books
                .Include(b => b.Genre)
                .ToList();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Genre)
                .SingleOrDefault(b => b.Id == id);

            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genre.ToList()
            };

            return View("BookForm", viewModel);
        }

        public IActionResult New()
        {
            var genres = _context.Genre.ToList();

            var viewModel = new BookFormViewModel
            {
                Genres = genres
=======
        private readonly IBookRepository repository;
        private readonly IGenreRepository genreRepository;

        public BooksController(IBookRepository repository, IGenreRepository genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var book = repository.GetBookById(id);

            if (book == null)
            {
                return Content("Book not found");
            }

            return View(book);
        }

        [Authorize(Roles = "Owner,StoreManager")]
        public IActionResult Edit(int id)
        {
            var book = repository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = genreRepository.GetGenres().ToList()
>>>>>>> Stashed changes
            };

            return View("BookForm", viewModel);
        }

<<<<<<< Updated upstream
        [HttpPost]
        public IActionResult Save(Book book)
        {
            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.AuthorName = book.AuthorName;
                bookInDb.GenreId = book.GenreId;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.NumberInStock = book.NumberInStock;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Books");
=======
        [Authorize(Roles = "Owner,StoreManager")]
        public IActionResult New()
        {
            var viewModel = new BookFormViewModel
            {
                Genres = genreRepository.GetGenres().ToList()
            };

            return View("BookForm", viewModel);
>>>>>>> Stashed changes
        }
    }
}
