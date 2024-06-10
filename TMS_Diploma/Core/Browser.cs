using AngleSharp;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Diploma.Utils;

namespace TMS_Diploma.Core
{
    internal class Browser
    {
        public IWebDriver Driver { get; set; }

        public Browser()
        {
            Driver = Configurator.ReadConfiguration().BrowserType.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFireFoxDriver(),
                _ => throw new NotSupportedException("This browser type wasn't found")
            };

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut);
            Driver.Manage().Window.Maximize();
        }
    }
}
