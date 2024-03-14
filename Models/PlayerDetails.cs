using System.ComponentModel.DataAnnotations;

namespace ChessAPIs.Models
{
    public class EnrollDetails
    {
        [Key]
        public string EmailID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FideId { get; set; }
        public string FideRating { get; set; }
        public string Level { get; set; }
    }
}
