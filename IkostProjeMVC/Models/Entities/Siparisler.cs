﻿namespace IkostProjeMVC.Models.Entities
{
    public class Siparisler
    {
        public int SiparisID { get; set; }
        public decimal SiparisTutar { get; set; }
        public decimal HakedisTutar { get; set; }
        public DateTime Tarih { get; set; }
        public string BayiAd{ get; set; }
        public int BayiID { get; set; }
        public virtual Bayiler Bayi { get; set; }
    }
}
