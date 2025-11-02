namespace PowerHouse.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public int ImpactApplied { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }
        public Activity? Activity { get; set; }
    }
}
