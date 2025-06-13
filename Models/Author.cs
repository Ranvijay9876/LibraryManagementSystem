using System.ComponentModel.DataAnnotations;

namespace LibraryRanvijayProject.Models
{
    public class Author
    {
        [Key]
        public int Authorid { get; set; }
        public String FName { get; set; }   
        public string LName { get; set; }
        public string Genre { get; set; }
    }
}
