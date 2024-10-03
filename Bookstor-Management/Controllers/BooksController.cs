using Bookstor_Management.Data;
using Bookstor_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstor_Management.Controllers
{
    public class BooksController : Controller
    {
        private readonly bookstoreDbContext _context;
        public BooksController(bookstoreDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }
        public async Task<IActionResult> Details(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return View(book);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return Content("Deleted successfully");
            }
            return Content("Book is not found");
        }
        public IActionResult Create()
        {
            Book book= new Book();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Price,Genre")] Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return Content("Book created successfully");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return Content("Book updated successfully");
        }
    }
}
