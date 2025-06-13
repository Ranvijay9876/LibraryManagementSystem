using System.ComponentModel.DataAnnotations;

namespace LibraryRanvijayProject.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string FName  { get; set; }
        public String lName { get; set; }
        public string Email { get; set; }
        public String phone { get; set; }
        public ICollection<BookBorrow> BookBorrows { get; set; }

    }
}
