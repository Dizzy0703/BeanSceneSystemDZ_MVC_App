using System.ComponentModel.DataAnnotations;

namespace BeanSceneSystem.Models
{
    /// <summary>
    /// Represents a reservation object, linked to the MemberGuest object with a foreign key 
    /// relationship.
    /// </summary>
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public int TableNo  { get; set; }
        [Required]
        public int NumOfGuests { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Sitting { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Notes { get; set; }
        public MemberGuest? MemberGuest { get; set; }
    }
}
