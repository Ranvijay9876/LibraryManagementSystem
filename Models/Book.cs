using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryRanvijayProject.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Tittle { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public string publisher { get; set; }
        public int year { get; set; }
        public int copiesAvailable { get; set; }

        public int LibraryId { get; set; }

        [ForeignKey("LibraryId")]
        public Library Library { get; set; }
        public ICollection<BookBorrowDetails> BookBorrowDetails { get; set; }






    }
}
