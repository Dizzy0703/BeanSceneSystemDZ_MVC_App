using System.ComponentModel.DataAnnotations;

namespace BeanSceneSystem.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ReservationId { get; set; }
    }
}
