using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryRanvijayProject.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public String StafFName { get; set; }
        public string StafLName { get; set; }
        public string position { get; set; }

        public int LibraryId { get; set; }

        [ForeignKey("LibraryId")]
        public Library Library { get; set; }


    }
}
