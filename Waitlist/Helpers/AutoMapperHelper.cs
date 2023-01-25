namespace Waitlist.Helpers
{
    /// <summary>
    /// AutoMapper is a library to reduce code required to map different objects to one another (ORM).
    /// https://docs.automapper.org/en/latest/ for docs
    /// </summary>
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {

            // AddUserRequest -> Users
            CreateMap<AddPassengerToWaitlistRequest, Passenger>();

        }

    }
}
