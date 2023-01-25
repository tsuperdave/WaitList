namespace Waitlist.Entity.Passenger
{
    [Table("waitlist")]
    public class Passenger
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LoungeCode { get; set; }
        public string UserCreation { get; set; } = "WaitlistApi";
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public string UserModification { get; set; } = "WaitlistApi";
        public DateTime DateModification { get; set; } = DateTime.Now;

    }
}
