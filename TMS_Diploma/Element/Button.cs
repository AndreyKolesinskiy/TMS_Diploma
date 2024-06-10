using OpenQA.Selenium;

namespace TMS_Diploma.Element
{
    public class Button
    {
        private readonly UiElement _uiElement;

        public Button(IWebDriver driver, By locator)
        {
            _uiElement = new UiElement(driver, locator);
        }

        public bool Displayed => _uiElement.Displayed;
        public bool Enabled => _uiElement.Enabled;
        public string Text => _uiElement.Text;

        public void Click()
        {
            _uiElement.Click();
        }

        public void Submit()
        {
            _uiElement.Submit();
        }
    }
}
