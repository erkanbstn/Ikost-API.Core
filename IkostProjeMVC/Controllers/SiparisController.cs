using IkostProjeMVC.Models.Context;
using IkostProjeMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IkostProjeMVC.Controllers
{
    public class SiparisController : Controller
    {
        private readonly Context _context;

        public SiparisController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // SQL = Select BayiID,BayiAd from Bayilers 
            List<SelectListItem> bayiler = (from x in _context.Bayilers.ToList()
                                            select new
                                            SelectListItem
                                            { Text = x.BayiAd, Value = x.BayiID.ToString() }
                                             ).ToList();
            ViewBag.bayi = bayiler;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Siparisler s)
        {
            // SQL = Select * from Bayilers where BayiID=s.BayiID
            var bayi = _context.Bayilers.Find(s.BayiID);
            s.HakedisTutar = s.SiparisTutar * (bayi.HakedisYuzde / 100);
            s.Tarih = DateTime.Now;
            s.BayiAd = bayi.BayiAd;
            // SQL = Insert into Siparislers values (s.HakedisTutar,s.Tarih,s.SiparisTutar,s.BayiID)
            _context.Siparislers.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
