using System.ComponentModel.DataAnnotations.Schema;

namespace DBFirst.Sample.Project.Models
{
    public class Reservation
    {
        public long Id { get; set; }
        [ForeignKey("ROOM_ID")]
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MainGuestDocument { get; set; } = null!;
        public string MainGuestName { get; set; } = null!;
        public string MainGuestEmail { get; set; } = null!;
        public bool IsConfirmed { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
