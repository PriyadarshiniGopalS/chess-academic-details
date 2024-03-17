using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessAPIs.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string School { get; set; }
        public string ParentName { get; set; }
        public string ParentEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string? FideID { get; set; }
        public int? FideRating { get; set; }
        public string? FideRatingLevel { get; set; }
    }
}