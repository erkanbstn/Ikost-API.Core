using IkostSipayAPI.SipayClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace IkostSipayAPI.Controllers
{
    public class IkostSipayController : Controller
    {
        private readonly IConfiguration _config;

        public IkostSipayController(IConfiguration config)
        {
            _config = config;

        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("IkostSipay/Index")]
        [HttpPost]
        public async Task<IActionResult> Index(string binCode, decimal amount)
        {
            Settings settings = new Settings();

            settings.AppID = _config["SIPAY:AppID"];
            settings.AppSecret = _config["SIPAY:AppSecret"];
            settings.MerchantKey = _config["SIPAY:MerchantKey"];
            settings.BaseUrl = _config["SIPAY:BaseUrl"];

            SipayGetPosRequest posRequest = new SipayGetPosRequest();

            posRequest.CreditCardNo = binCode;
            posRequest.Amount = amount;
            posRequest.CurrencyCode = "TRY";
            posRequest.MerchantKey = _config["SIPAY:MerchantKey"];
            //posRequest.IsRecurring = true;
            SipayGetPosResponse posResponse = SipayPaymentService.GetPos(posRequest, settings, GetAuthorizationToken(settings));

            return Json(new { values = posResponse });
        }
        [NonAction]
        public string GetAuthorizationToken(Settings settings)
        {

            //if (HttpContext.Session.Get<SipayTokenResponse>("token") == default)
            //{
            //    SipayTokenResponse tokenResponse = SipayPaymentService.CreateToken(settings);

            //    HttpContext.Session.Set<SipayTokenResponse>("token", tokenResponse);
            //}

            //return HttpContext.Session.Get<SipayTokenResponse>("token");

            return "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIyNSIsImp0aSI6IjBiYzlmZmRlMjRjZjc2NGRkYzA4MjA4OTdlMmU3YjlkNjI3OTI5YWZkN2I2YmM1NzQ5MmNhN2YyMzQxNTU2NGQ1M2EzMTc5ODMwOTBlNzgwIiwiaWF0IjoxNjgzMzc2MDI5Ljk0NjQsIm5iZiI6MTY4MzM3NjAyOS45NDY0LCJleHAiOjE2ODMzODMyMjkuNzA0Nywic3ViIjoiODYiLCJzY29wZXMiOltdfQ.DGFTrtrZdg9A8y-iBIu7ju9WhZ5TEuUSSOyNx6miidCWxsEzNPOl9O6J7daqYgAWy7KdSK2GNq9xj5XZm3d9qBio7CjFhPJRAuqB1PZ-75Y7fvyfbIN-nFCy8K0LvOsk7yZP42NeRqNx8pbesOTyJ6dPA6Q-c6qv9DHT1g85WmyZsoItVDKK3MATkeOiy93GL-SmF8NlSqgql1rS4_UD5YhYihPBRMcuvNM9riuvqrY8nUwYx5smM8gFwzboMgp5z1DKfeFA-NbJeOAo9otOODr4HRiw4fJfsq9iLv4XKgz3fPJ-BBHIkoMVTP3dVTkI1I2yl1PfkKouahezoeuC1PguzYLz75Mzltv3qRXWAP9_fPvPds4-OlHy-4Qr4_v9zK9AzbGJBmRh42wvCHKr_r7Zq-Fucf26rZYSWuJMwvvLkX0Lh0lmWWSl-aRGhUw37WG7nuVaMmWDaY7wFaMEvTfk4y3dPLZ67P5-_cw7Ni1_rNC1fXtUc-Qx1yj392NYIxGQWwsdRqVDnF2IQO68nAW0KefgWvWMW1Z4IVrwkkkU2NZptmhoQI8WxgKbT11xRq3HlxuoRZXtfRmyjhJP6OV8naD4D2eCpUi_zHDFSx2kUpOAO_0VK94zx3usjqXtcIzme6JC192II9TUfk9Uvzl1rPiecRlC7sXkSHsTdMQ";

        }
    }
}
