namespace Waitlist.Entity.Aws
{
    [Table("awscredentials")]
    public class AwsCredentials
    {
        [Key]
        public int? Id { get; set; }
        public string ModuleName { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime ModificationDate { get; set; }
        public string ModificationUser { get; set; }
        public string Hash { get; set; }
        public string PassCode { get; set; }

    }
}
