using IkostProjeMVC.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace IkostProjeMVC.ViewComponents
{
    public class BayiList : ViewComponent
    {
        private readonly Context _context;

        public BayiList(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Bayilers.ToList();
            return View(values);
        }
    }
}
