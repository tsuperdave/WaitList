namespace Waitlist.Helpers
{
    public class AppSettings
    {
        public Amazon Amazon { get; set; }
        //public ConnectionStrings ConnectionStrings { get; set; }

    }

    public class Amazon
    {
        public string Region { get; set; }
        public string S3_BUCKET_EX{ get; set; }
    }

    //public class ConnectionStrings
    //{
    //    public string ARS { get; set; }
    //    public string LMS { get; set; }
    //}

}
