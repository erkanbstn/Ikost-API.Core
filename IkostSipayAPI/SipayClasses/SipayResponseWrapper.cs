using System;
using System.Collections.Generic;

namespace IkostSipayAPI.SipayClasses
{
    public class SipayResponseWrapper
    {
        public string status_code { get; set; }
        public string status_description { get; set; }
        public string message { get; set; }

    }
}

