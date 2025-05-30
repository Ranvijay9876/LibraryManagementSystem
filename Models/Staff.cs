using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryRanvijayProject.Models
{
    public class Staff
    {
        public string StaffId  { get; set; }
        public string StaffName { get; set; }
        public string position { get; set; }

        public int LibraryId { get; set; }

        [ForeignKey("LibraryId")]
        public Library Library { get; set; }

    }
}
