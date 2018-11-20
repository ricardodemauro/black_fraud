﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Domain.Models
{
    public class VendorProduct : Product
    {
        public decimal Price { get; set; }

        public DateTime Modified { get; set; }
    }
}
