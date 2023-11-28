namespace DBFirst.Sample.Project.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public long Number { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
