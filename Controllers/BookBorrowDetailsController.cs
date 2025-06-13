using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryRanvijayProject.Data;
using LibraryRanvijayProject.Models;

namespace LibraryRanvijayProject.Controllers
{
    public class BookBorrowDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookBorrowDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookBorrowDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookBorrowDetails.Include(b => b.Book).Include(b => b.BookBorrow);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookBorrowDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrowDetails = await _context.BookBorrowDetails
                .Include(b => b.Book)
                .Include(b => b.BookBorrow)
                .FirstOrDefaultAsync(m => m.BorrowDetailId == id);
            if (bookBorrowDetails == null)
            {
                return NotFound();
            }

            return View(bookBorrowDetails);
        }

        // GET: BookBorrowDetails/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookId");
            ViewData["BorrowId"] = new SelectList(_context.BookBorrow, "borrowId", "borrowId");
            return View();
        }

        // POST: BookBorrowDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowDetailId,BorrowId,BookId")] BookBorrowDetails bookBorrowDetails)
        {

                      //if (ModelState.IsValid)
            //{      _context.Add(bookBorrowDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookId", bookBorrowDetails.BookId);
            ViewData["BorrowId"] = new SelectList(_context.BookBorrow, "borrowId", "borrowId", bookBorrowDetails.BorrowId);
            return View(bookBorrowDetails);
        }

        // GET: BookBorrowDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrowDetails = await _context.BookBorrowDetails.FindAsync(id);
            if (bookBorrowDetails == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookId", bookBorrowDetails.BookId);
            ViewData["BorrowId"] = new SelectList(_context.BookBorrow, "borrowId", "borrowId", bookBorrowDetails.BorrowId);
            return View(bookBorrowDetails);
        }

        // POST: BookBorrowDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowDetailId,BorrowId,BookId")] BookBorrowDetails bookBorrowDetails)
        {
            if (id != bookBorrowDetails.BorrowDetailId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(bookBorrowDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookBorrowDetailsExists(bookBorrowDetails.BorrowDetailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookId", bookBorrowDetails.BookId);
            ViewData["BorrowId"] = new SelectList(_context.BookBorrow, "borrowId", "borrowId", bookBorrowDetails.BorrowId);
            return View(bookBorrowDetails);
        }

        // GET: BookBorrowDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrowDetails = await _context.BookBorrowDetails
                .Include(b => b.Book)
                .Include(b => b.BookBorrow)
                .FirstOrDefaultAsync(m => m.BorrowDetailId == id);
            if (bookBorrowDetails == null)
            {
                return NotFound();
            }

            return View(bookBorrowDetails);
        }

        // POST: BookBorrowDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookBorrowDetails = await _context.BookBorrowDetails.FindAsync(id);
            if (bookBorrowDetails != null)
            {
                _context.BookBorrowDetails.Remove(bookBorrowDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookBorrowDetailsExists(int id)
        {
            return _context.BookBorrowDetails.Any(e => e.BorrowDetailId == id);
        }
    }
}
