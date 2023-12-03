using System.ComponentModel.DataAnnotations;

namespace ChessAPIs.Models
{
    public class PlayerDetails
    {
        [Key]
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
    }
}
