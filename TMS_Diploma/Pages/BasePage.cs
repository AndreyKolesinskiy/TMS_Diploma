using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TMS_Diploma.Utils;

namespace TMS_Diploma.Pages
{
    public abstract class BasePage : LoadableComponent<BasePage>
    {
        protected IWebDriver Driver { get; set; }
        public WaitsHelper? WaitsHelper;

        public BasePage(IWebDriver driver, bool opePageByUrl = false)
        {
            Driver = driver;
            WaitsHelper = new WaitsHelper(driver);
            if (opePageByUrl)
                Load();
        }
        public abstract string GetEndpoint();

        public void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().BaseTRUrl + GetEndpoint());
        }

        protected override void ExecuteLoad()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().BaseTRUrl + GetEndpoint());
        }
    }
}
