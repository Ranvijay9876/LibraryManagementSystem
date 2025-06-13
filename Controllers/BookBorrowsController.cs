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
    public class BookBorrowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookBorrowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookBorrows
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookBorrow.Include(b => b.Member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookBorrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.borrowId == id);
            if (bookBorrow == null)
            {
                return NotFound();
            }

            return View(bookBorrow);
        }

        // GET: BookBorrows/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "MemberId");
            return View();
        }

        // POST: BookBorrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("borrowId,LoanDate,Duedate,ReturnDate,MemberId")] BookBorrow bookBorrow)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(bookBorrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "MemberId", bookBorrow.MemberId);
            return View(bookBorrow);
        }

        // GET: BookBorrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow.FindAsync(id);
            if (bookBorrow == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "MemberId", bookBorrow.MemberId);
            return View(bookBorrow);
        }

        // POST: BookBorrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("borrowId,LoanDate,Duedate,ReturnDate,MemberId")] BookBorrow bookBorrow)
        {
            if (id != bookBorrow.borrowId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(bookBorrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookBorrowExists(bookBorrow.borrowId))
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
            ViewData["MemberId"] = new SelectList(_context.Member, "MemberId", "MemberId", bookBorrow.MemberId);
            return View(bookBorrow);
        }

        // GET: BookBorrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookBorrow = await _context.BookBorrow
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.borrowId == id);
            if (bookBorrow == null)
            {
                return NotFound();
            }

            return View(bookBorrow);
        }

        // POST: BookBorrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookBorrow = await _context.BookBorrow.FindAsync(id);
            if (bookBorrow != null)
            {
                _context.BookBorrow.Remove(bookBorrow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookBorrowExists(int id)
        {
            return _context.BookBorrow.Any(e => e.borrowId == id);
        }
    }
}
