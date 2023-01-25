namespace Waitlist.Models.Passenger
{
    public class AddPassengerToWaitlistRequest
    {
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [StringLength(4)]
        public string LoungeCode { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(2), MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public int Guests { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [JsonIgnore]
        public string UserCreation { get; set; } = "WaitlistApi";

        [JsonIgnore]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        [JsonIgnore]
        public string UserModification { get; set; } = "WaitlistApi";

        [JsonIgnore]
        public DateTime DateModification { get; set; } = DateTime.Now;

    }
}
