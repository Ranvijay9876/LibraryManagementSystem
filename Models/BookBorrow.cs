//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Security.Principal;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRanvijayProject.Models
{
    public class BookBorrow
    {
        [Key]
        public int borrowId { get; set; }
        public DateOnly LoanDate { get; set; }
        public DateOnly Duedate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member Member { get; set; }
        public ICollection<BookBorrowDetails> BookBorrowDetails { get; set; }

    }
}
