using Waitlist.Helpers;
using Waitlist.Models.Passenger;
using Waitlist.Services;

namespace Waitlist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : Controller
    {
        private IPassengerService _passengerService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public PassengerController(IPassengerService passengerService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _passengerService = passengerService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet("/")]
        public string apiHealthRes()
        {
            return Environment.GetEnvironmentVariable("DB_CONNECT");
        }

        [HttpPost("addToWaitlist")]
        public IActionResult AddPassengerToWaitlist(AddPassengerToWaitlistRequest model)
        {

            _passengerService.AddPassengerToWaitlist(model);

            return Ok(new { message = "Passenger Added Successfully!" });
        }

        [HttpGet("getImage/{loungeCode}")]
        public IActionResult GetLoungeImage(string loungeCode)
        {
            var lounge = _passengerService.GetLoungeImage(loungeCode);

            return Ok(lounge);

        }

    }
}
