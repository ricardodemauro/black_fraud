using BlackFraud.Domain.Behaviors;
using BlackFraud.Domain.Models;
using BlackFraud.Repository.MariaDb.Insfrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Repository.MariaDb.Persisters
{
    public partial class MariaVendorProductPersister : IVendorProductPersister
    {
        private readonly MariaDbConfigOptions _mariaDbConfigOptions;
        private readonly ILogger<MariaVendorProductPersister> _logger;

        public MariaVendorProductPersister(IOptions<MariaDbConfigOptions> mariaDbConfigOptions, ILogger<MariaVendorProductPersister> logger)
        {
            _mariaDbConfigOptions = mariaDbConfigOptions.Value;
            _logger = logger;
        }

        public void AddVendorProduct(VendorProduct vendorProduct)
        {
            if (vendorProduct == null)
                throw new ArgumentNullException(nameof(vendorProduct));

            using (IDbConnection db = new MySqlConnection(_mariaDbConfigOptions.ConnectionString))
            {
                try
                {
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandText = insert_product_sql;
                        cmd.CommandType = CommandType.Text;

                        var paramUrl = new MySqlParameter("@Url", MySqlDbType.VarChar);
                        paramUrl.Direction = ParameterDirection.Input;
                        paramUrl.Value = vendorProduct.Url;
                        cmd.Parameters.Add(paramUrl);

                        var paramVendorCode = new MySqlParameter("@VendorCode", MySqlDbType.VarChar);
                        paramVendorCode.Direction = ParameterDirection.Input;
                        paramVendorCode.Value = vendorProduct.VendorCode;
                        cmd.Parameters.Add(paramVendorCode);

                        var paramPrice = new MySqlParameter("@Price", MySqlDbType.Decimal);
                        paramPrice.Direction = ParameterDirection.Input;
                        paramPrice.Value = vendorProduct.Price;
                        cmd.Parameters.Add(paramPrice);

                        var paramCode = new MySqlParameter("@Code", MySqlDbType.VarChar);
                        paramCode.Direction = ParameterDirection.Input;
                        paramCode.Value = vendorProduct.Code;
                        cmd.Parameters.Add(paramCode);

                        var paramDisplayName = new MySqlParameter("@DisplayName", MySqlDbType.VarChar);
                        paramDisplayName.Direction = ParameterDirection.Input;
                        paramDisplayName.Value = vendorProduct.DisplayName;
                        cmd.Parameters.Add(paramDisplayName);

                        db.Open();

                        int codeReturn = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(MariaDbEventCodes.DbAddingWebProduct, ex, "Error when interacting with db {EXCEPTION}", ex.Message);
                    throw ex;
                }
                finally
                {
                    if (db.State != ConnectionState.Closed)
                        db.Close();
                }
            }
        }
    }
}
