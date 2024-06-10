using OpenQA.Selenium;
using TMS_Diploma.BaseEntities;
using TMS_Diploma.Element;

namespace TMS_Diploma.Pages
{
    public class TRDashboardPage : BasePage
    {
        private string _endPoint = "index.php?/dashboard";
        public UiElement AddProjectButton() => new(Driver, By.Id("sidebar-projects-add"));

        public TRDashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return AddProjectButton().Displayed;
        }
    }
}
