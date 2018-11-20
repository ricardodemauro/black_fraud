using BlackFraud.Domain.Infrastrucuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Application.WebSelenium.Infrastrucutre
{
    public class SeleniumConfiguration
    {
        public string FirefoxPath { get; set; }

        public string ChromePath { get; set; }

        public int Timeout { get; set; }

        public bool EnableImages { get; set; }

        public Browsers Browser { get; set; }

        public bool Headless { get; set; }
    }
}
