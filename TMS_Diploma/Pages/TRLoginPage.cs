using OpenQA.Selenium;
using TMS_Diploma.Element;
using TMS_Diploma.Utils;

namespace TMS_Diploma.Pages
{
    public class TRLoginPage : BasePage
    {
        private string _endPoint = "";
        public UiElement EmailField() => new(Driver, By.Id("name"));
        public UiElement PasswordField() => new(Driver, By.Id("password"));
        public UiElement LogInButton() => new(Driver, By.Id("button_primary"));

        public TRLoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        public void SuccessfulLogin()
        {
            ExecuteLoad();
            EmailField().SendKeys(Configurator.ReadConfiguration().TRLogin);
            PasswordField().SendKeys(Configurator.ReadConfiguration().TRPassword);
            LogInButton().Click();
        }

        protected override bool EvaluateLoadedStatus()
        {
            return LogInButton().Displayed;
        }
    }
}
