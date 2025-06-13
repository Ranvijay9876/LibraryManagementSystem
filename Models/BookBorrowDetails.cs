using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace LibraryRanvijayProject.Models
{
    public class BookBorrowDetails
    {
        [Key]
        public int BorrowDetailId { get; set; }
        public int BorrowId { get; set; }
        [ForeignKey("BorrowId")]
        public BookBorrow BookBorrow { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
