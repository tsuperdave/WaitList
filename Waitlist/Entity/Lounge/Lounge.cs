namespace Waitlist.Entity.Lounge
{
    [Table("lounges")]
    public class Lounge
    {
        [Key]
        public string? LoungeCode { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime ModificationDate { get; set; }
        public string AirportCode { get; set; }
        public string TimeZone { get; set; }
        [JsonIgnore]
        public string AuthorizeNetLogin { get; set; }
        [JsonIgnore]
        public string AuthorizeNetKey { get; set; }
        public string Airport { get; set; }

        public string Website { get; set; }
        public string Phone { get; set; }
        public bool isChaseLounge { get; set; }
        public string WaitlistEmailLogo { get; set; }
    }
}
