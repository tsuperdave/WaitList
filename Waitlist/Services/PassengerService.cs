using Waitlist.Entity.Passenger;
using Waitlist.Helpers;
using Waitlist.Models.Passenger;

namespace Waitlist.Services
{
    public interface IPassengerService
    {
        void AddPassengerToWaitlist(AddPassengerToWaitlistRequest model);
        GetLoungeInfoRequest GetLoungeImage(string loungeCode);

    }
    public class PassengerService : IPassengerService
    {

        private DataContextPROD _dataContextPROD;
        private readonly IMapper _mapper;
        //private readonly IAmazonSecretsManager _secretsManager;

        public PassengerService(DataContext dataContext, IMapper mapper)
        {
            _dataContextPROD = dataContext;
            _mapper = mapper;
        }

        public void AddPassengerToWaitlist(AddPassengerToWaitlistRequest model)
        {
            if (model == null) throw new ApplicationException("No Passenger Information Provided");

            if (model.Name == null) throw new ApplicationException("Name field empty");

            if (model.LoungeCode == null) throw new ApplicationException("Lounge Code invalid");

            var passenger = _mapper.Map<Passenger>(model);

            _dataContextPROD.Passenger.Add(passenger);
            _dataContextPROD.SaveChanges();

        }

        public GetLoungeInfoRequest GetLoungeImage(string loungeCode)
        {
            if (loungeCode.Length > 4 || loungeCode.Length <= 0) throw new ApplicationException("Lounge Code length must be 1-4 characters in length.");

            if (loungeCode == null) throw new ApplicationException("Lounge code empty");

            var lounge = _dataContextPROD.Lounge.Find(loungeCode);
            if (lounge == null) throw new KeyNotFoundException("Lounge not found");

            GetLoungeInfoRequest loungeInfo = new();
            loungeInfo.LoungeName = lounge.Name;
            loungeInfo.LoungeCode = loungeCode;
            loungeInfo.WaitlistEmailLogo = lounge.WaitlistEmailLogo;

            return loungeInfo;
        }

    }

}
