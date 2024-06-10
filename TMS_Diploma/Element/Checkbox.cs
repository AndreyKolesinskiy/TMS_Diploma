using OpenQA.Selenium;
using TMS_Diploma.Utils;

namespace TMS_Diploma.Element
{
    public class Checkbox
    {
        private readonly List<UiElement> _uiElements;
        private readonly List<string> _texts;
        private readonly WaitsHelper _waitsHelper;

        public Checkbox(IWebDriver driver, By locator)
        {
            _waitsHelper = new WaitsHelper(driver);
            _uiElements = new List<UiElement>();
            _texts = new List<string>();

            foreach (var element in _waitsHelper.WaitForElementsPresence(locator))
            {
                var uiElement = new UiElement(driver, element);
                _uiElements.Add(uiElement);
                _texts.Add(element.FindElement(By.XPath("//*[@type='checkbox']")).Text.Trim().ToLower());
            }
        }

        public void SelectByIndex(int index)
        {
            if (index < _uiElements.Count && index >= 0)
            {
                if (!_uiElements[index].Selected)
                    _uiElements[index].Click();
            }
            else
                throw new ArgumentOutOfRangeException($"Couldn't find element with this index: {index}");
        }

        public void UnselectByIndex(int index)
        {
            if (index < _uiElements.Count && index >= 0)
            {
                if (_uiElements[index].Selected)
                    _uiElements[index].Click();
            }
            else
                throw new ArgumentOutOfRangeException($"Couldn't find element with this index: {index}");
        }

        public void SelectByText(string text)
        {
            if (!_uiElements[_texts.IndexOf(text.ToLower().Trim())].Selected)
                _uiElements[_texts.IndexOf(text.ToLower().Trim())].Click();
        }

        public void UnselectByText(string text)
        {
            if (_uiElements[_texts.IndexOf(text.ToLower().Trim())].Selected)
                _uiElements[_texts.IndexOf(text.ToLower().Trim())].Click();
        }

        public void SelectAll()
        {
            foreach (var element in _uiElements)
                if (!element.Selected)
                    element.Click();
        }

        public void UnselectAll()
        {
            foreach (var element in _uiElements)
                if (element.Selected)
                    element.Click();
        }

        public void EnableCheckbox()
        {
            if (!_uiElements[0].Selected)
                _uiElements[0].Click();
        }

        public void DisableCheckbox()
        {
            if (_uiElements[0].Selected)
                _uiElements[0].Click();
        }
    }
}
