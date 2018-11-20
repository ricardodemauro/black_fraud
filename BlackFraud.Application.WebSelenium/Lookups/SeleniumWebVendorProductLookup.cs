using BlackFraud.Application.WebSelenium.Infrastrucutre;
using BlackFraud.Domain.Behaviors;
using BlackFraud.Domain.Infrastrucuture;
using BlackFraud.Domain.Models;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Application.WebSelenium.Lookups
{
    public sealed class SeleniumWebVendorProductLookup : IWebVendorProductLookup, IDisposable
    {
        private readonly SeleniumConfiguration _seleniumConfiguration;
        private IWebDriver _driver;
        private bool _initialized;

        public SeleniumWebVendorProductLookup(IOptions<SeleniumConfiguration> seleniumConfiguration)
        {
            _seleniumConfiguration = seleniumConfiguration.Value;
        }

        private void EnsureInitialized()
        {
            if (!_initialized)
            {
                switch (_seleniumConfiguration.Browser)
                {
                    case Browsers.Firefox:
                        {
                            FirefoxOptions options = new FirefoxOptions();
                            if (_seleniumConfiguration.Headless)
                                options.AddArgument("--headless");

                            if (!_seleniumConfiguration.EnableImages)
                            {
                                FirefoxProfile profile = new FirefoxProfile();
                                profile.SetPreference("permissions.default.image", 2);
                                options.Profile = profile;
                            }
                            _driver = new FirefoxDriver(_seleniumConfiguration.FirefoxPath, options);
                        }
                        break;
                    case Browsers.Chrome:
                        {
                            ChromeOptions options = new ChromeOptions();
                            if (_seleniumConfiguration.Headless)
                                options.AddArgument("--headless");

                            if (!_seleniumConfiguration.EnableImages)
                            {
                                options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
                            }
                            _driver = new ChromeDriver(_seleniumConfiguration.ChromePath, options);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(_seleniumConfiguration.Browser));
                }
            }
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }

        public WebProduct GetWebProduct(WebProduct webProduct)
        {
            EnsureInitialized();

            LoadPage(webProduct.Url);

            webProduct.DisplayName = _driver.FindElement(By.ClassName("product-name")).Text;
            webProduct.Price = _driver.FindElement(By.ClassName("sales-price")).Text;

            return webProduct;
        }

        private void LoadPage(Uri url)
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_seleniumConfiguration.Timeout);
            _driver.Navigate().GoToUrl(url.AbsoluteUri);
        }
    }
}
