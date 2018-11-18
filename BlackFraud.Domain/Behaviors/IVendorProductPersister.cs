using BlackFraud.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Domain.Behaviors
{
    public interface IVendorProductPersister
    {
        void AddVendorProduct(VendorProduct vendorProduct);
    }
}
