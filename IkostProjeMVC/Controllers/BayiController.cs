using IkostProjeMVC.Models.Context;
using IkostProjeMVC.Models.CustomHelper;
using IkostProjeMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IkostProjeMVC.Controllers
{
    public class BayiController : Controller
    {
        private readonly Context _context;

        public BayiController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Bayiler b)
        {
            // SQL = Select * from Bayilers where BayiAd=@BayiAd
            var onBayi = _context.Bayilers.FirstOrDefault(c => c.BayiAd == b.BayiAd);
            if (onBayi == null)
            {
                // SQL = Insert into Bayilers values (b.BayiAd,b.HakedisYuzde)
                _context.Bayilers.Add(b);
                _context.SaveChanges();
                ViewBag.mevcut = 1;
                return RedirectToAction("Index");
            }
            ViewBag.mevcut = 0;
            return View();
        }
        public IActionResult Rapor()
        {
            return View();

        }
        [Route("Bayi/Rapor")]
        [HttpPost]
        public JsonResult Rapor(ReportDate t)
        {
            // SQL = Select s.BayiAd 'Bayi',SUM(s.HakedisTutar) 'ToplamHakEdis' from Siparislers s where s.Tarih > @Tarih1 and s.Tarih < @Tarih2 group by s.BayiAd
            var rapor = _context.Siparislers.Where(b => b.Tarih > t.Tarih1 && b.Tarih < t.Tarih2).Select(b => new { b.BayiAd, b.HakedisTutar }).GroupBy(i => i.BayiAd).Select(g => new
            {
                Bayi = g.Key,
                ToplamHakEdis = g.Sum(s => s.HakedisTutar)
            }).ToList();

            return Json(new { sonuc = rapor });
        }
        [Route("Bayi/BayiSil")]
        [HttpPost]
        public IActionResult BayiSil(int id)
        {
            // SQL = Select * from Siparislers where BayiID=@id
            var onSiparis = _context.Siparislers.FirstOrDefault(b => b.BayiID == id);
            if (onSiparis == null)
            {
                // SQL = Delete from Bayilers where id=@id
                _context.Bayilers.Remove(_context.Bayilers.Find(id));
                _context.SaveChanges();
                return Json(new { transaction = true });
            }
            return Json(new { transaction = false });
        }
    }
}
