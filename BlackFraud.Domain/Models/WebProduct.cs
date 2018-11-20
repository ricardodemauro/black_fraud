using BlackFraud.Domain.Infrastrucuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Domain.Models
{
    public class WebProduct : Product
    {
        public SearchBy DisplaySearchBy { get; set; }

        public string DisplayNameXPath { get; set; }

        public SearchBy PriceSearchBy { get; set; }

        public string PriceXPath { get; set; }
    }
}
