using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Repository.MariaDb.Persisters
{
    public partial class MariaVendorProductPersister
    {
        internal readonly string insert_product_sql = @"INSERT INTO WebProduct 
            (
                Url, 
                VendorCode, 
                Price, 
                Code, 
                DisplayName
            ) 
            VALUES 
            (
                @Url, 
                @VendorCode,
                @Price,
                @Code,
                @DisplayName
            )";
    }
}
