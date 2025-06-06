using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryRanvijayProject.Models;

namespace LibraryRanvijayProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LibraryRanvijayProject.Models.Author> Author { get; set; } = default!;
        public DbSet<LibraryRanvijayProject.Models.Library> Library { get; set; } = default!;
        public DbSet<LibraryRanvijayProject.Models.Member> Member { get; set; } = default!;
        public DbSet<LibraryRanvijayProject.Models.Book> Book { get; set; } = default!;
        public DbSet<LibraryRanvijayProject.Models.BookBorrow> BookBorrow { get; set; } = default!;
        public DbSet<LibraryRanvijayProject.Models.BookBorrowDetails> BookBorrowDetails { get; set; } = default!;
        public DbSet<LibraryRanvijayProject.Models.Staff> Staff { get; set; } = default!;
    }
}
