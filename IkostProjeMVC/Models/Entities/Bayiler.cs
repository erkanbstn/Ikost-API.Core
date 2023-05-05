

namespace IkostProjeMVC.Models.Entities
{
    public class Bayiler
    {
        public int BayiID { get; set; }
        public string BayiAd { get; set; }
        public int HakedisYuzde { get; set; }
        public List<Siparisler> Siparislers { get; set; }
    }
}
