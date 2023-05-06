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
            SipayGetPosResponse posResponse = SipayPaymentService.GetPos(posRequest, settings, GetAuthorizationToken(/*settings*/));

            return Json(new { values = posResponse });
        }
        [NonAction]
        public string GetAuthorizationToken(/*Settings settings*/)
        {
            //if (HttpContext.Session.Get<SipayTokenResponse>("token") == default)
            //{
            //    SipayTokenResponse tokenResponse = SipayPaymentService.CreateToken(settings);

            //    HttpContext.Session.Set<SipayTokenResponse>("token", tokenResponse);
            //}

            //return HttpContext.Session.Get<SipayTokenResponse>("token");

            return "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIyNSIsImp0aSI6IjcwN2EyMGY3YTEwMmUwODdmZTMyNmYzNTk0Y2U4MTYzODg0YzIyYjMwMDQzNzhhMjkzNGMyMjgzNDFhOTRkYWMzMTAwYjBhMTBjYjFmZjcwIiwiaWF0IjoxNjgzMzk5NTkxLjc2ODIsIm5iZiI6MTY4MzM5OTU5MS43NjgyLCJleHAiOjE2ODM0MDY3OTEuNzYyNSwic3ViIjoiODYiLCJzY29wZXMiOltdfQ.k4gc5nx9bIJ52gwu4QcuZ493qUAb2NF81NCbmBdw3VKiIwqHS4zMZSpu-JpFKaTUcWuThBoGFuk1L2-SiTcXi_95j-PuBsztViw_VemfKuYmD8ICW7ofqhkBHLKBkD7gycl_MJ0zZILNc7ITvfpRXsQNHdeV969auGrXlQhVS2j3EhCGWgylvz7d14xhF9dL8Cr8054uxDJCRgHXAwbq4Ak8XCHJrxtd1R2hVYXXMwRgVpi_2DGaIIfA8lo_FiylyUEVhE7eZFrfbxXAAQlQskQFZ6C-nDP-2en5yaeH1N-Ek9A7G70tN4j6dwT4Fugdw3fhTnhvRg2eDZYvsjdsb2uiwfPdMyj6Om_2BOYEFSYz4Uq__ncufuJt3t_Pyss4EKrBheOsG_X2wj6EErcp8_0WxTR2YXm-UYCY-dtk8LwigWsyeLzq-93lhvJPxc0Th4xzFi6IsxETAogQydAVgEwLFPx5oRJWjo2YD6nBR0UQL-0vuy2_-Vt8eG9dElxGYwjV3_Q8wPX_DGJlW7F9CYFuGweeBzDM9IplUwC3pYaTnwZYT3tgE5_JQlM_XKrN_y_zto_JCSkAlUcY59E3vG8H3oa4wXPZayg2qTE5fXF9QLIW4ctbkRYjGUF9L_qbFvvAKkMOXQ2i4N88uZJiLcw6gD0pQ0_McrbyavX2QN0";

        }
    }
}
