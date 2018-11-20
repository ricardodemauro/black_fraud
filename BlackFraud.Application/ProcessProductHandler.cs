using BlackFraud.Application.Infrastrucure;
using BlackFraud.DI;
using BlackFraud.Domain.Behaviors;
using BlackFraud.Domain.Commands;
using BlackFraud.Domain.Infrastrucuture;
using BlackFraud.Domain.Models;
using Microsoft.Extensions.Logging;
using System;

namespace BlackFraud.Application
{
    public sealed class ProcessProductHandler : IHandler<ProcessProductRequest, ProcessProductResponse>
    {
        private readonly IWebVendorProductLookup _webVendorProductLookup;

        private readonly IVendorProductPersister _vendorProductPersister;

        private readonly ILogger<ProcessProductHandler> _logger;

        public ProcessProductHandler(IWebVendorProductLookup webVendorProductLookup, IVendorProductPersister vendorProductPersister, ILogger<ProcessProductHandler> logger)
        {
            _webVendorProductLookup = webVendorProductLookup;
            _vendorProductPersister = vendorProductPersister;
            _logger = logger;
        }

        public ProcessProductResponse Handle(ProcessProductRequest rq)
        {
            if (rq == null)
                throw new ArgumentNullException(nameof(rq));

            _logger.LogTrace(LoggerCodes.InitProcessProduct, "Beggining handle {TIME}", DateTime.Now.ToLongDateString());

            var webProduct = new WebProduct
            {
                Code = "126831715",
                DisplaySearchBy = SearchBy.ClassName,
                DisplayNameXPath = "product-name",
                PriceSearchBy = SearchBy.ClassName,
                PriceXPath = "sales-price",
                Url = new Uri("https://www.submarino.com.br/produto/126831715")
            };
            var webProdResponse = _webVendorProductLookup.GetWebProduct(webProduct);

            PersistProduct(webProdResponse);

            var response = new ProcessProductResponse();
            response.Status = "Ok";
            return response;
        }

        private void PersistProduct(WebProduct webProduct)
        {
            VendorProduct prod = new VendorProduct
            {
                Code = webProduct.Code,
                DisplayName = webProduct.DisplayName,
                Modified = DateTime.UtcNow,
                Price = 0,
                Url = webProduct.Url.AbsoluteUri,
                VendorCode = webProduct.Code
            };

            _vendorProductPersister.AddVendorProduct(prod);
        }
    }
}
