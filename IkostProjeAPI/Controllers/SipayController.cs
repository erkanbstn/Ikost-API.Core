using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay.Models;

namespace IkostProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SipayController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SipayController(IConfiguration config)
        {
            _config = config;
        }
        static HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            Settings settings = new Settings();
            settings.AppID = _config["SIPAY:AppID"];
            settings.AppSecret = _config["SIPAY:AppSecret"];
            settings.MerchantKey = _config["SIPAY:MerchantKey"];
            settings.BaseUrl = _config["SIPAY:BaseUrl"];

            string path = $"{settings.BaseUrl}/api/getpos";

            HttpResponseMessage response = await client.GetAsync(path);

            return Ok(response.StatusCode);
        }
    }
}
