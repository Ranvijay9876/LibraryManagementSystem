using System.ComponentModel.DataAnnotations;

namespace LibraryRanvijayProject.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }

        public ICollection<Book> Book { get; set; }
        public ICollection<Staff> Staff { get; set; }   


    }
}
