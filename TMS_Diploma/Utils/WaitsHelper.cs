using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace TMS_Diploma.Utils
{
    public class WaitsHelper
    {
        private IWebDriver driver;
        private WebDriverWait _wait;
        private TimeSpan _timeout;

        public WaitsHelper(IWebDriver driver)
        {
            this.driver = driver;
            _timeout = TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut);
            _wait = new WebDriverWait(driver, _timeout);
        }

        public IWebElement WaitForVisibility(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IAlert WaitForAlertIsPresent()
        {
            return _wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public bool WaitForElementInvisible(By locator)
        {
            return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public bool WaitForElementInvisible(IWebElement element)
        {
            try
            {
                _wait.Until(d => !element.Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Element visible after {_timeout} seconds");
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        }
        public IWebElement WaitForExist(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public IReadOnlyCollection<IWebElement> WaitForElementsPresence(By locator)
        {
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }

    }
}
