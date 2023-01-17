using System.ComponentModel.DataAnnotations;

namespace BeanSceneSystem.Models
{
    /// <summary>
    /// Represents a Member/Guest, which is linked to the Reservation object 
    /// if there are any reservations with the correct UserID.
    /// </summary>
    public class MemberGuest
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
