using OpenQA.Selenium;
using TMS_Diploma.Element;

namespace TMS_Diploma.Pages
{
    public class TRProjectsPage : BasePage
    {
        private string _endPoint = "index.php?/admin/projects/overview";

        public Checkbox DeleteCheckbox() => new(Driver, By.XPath("//*[@role='dialog']//*[@name='deleteCheckbox']"));
        public UiElement DeleteDialogOKButtton() => new(Driver, By.XPath("//*[@role='dialog']//*[@data-testid='caseFieldsTabDeleteDialogButtonOk']"));
        public UiElement ProjectsPageTitle() => new(Driver, By.XPath("//*[@data-testid='testCaseContentHeaderTitle']"));
        public UiElement GetNewCreatedProjectElement(string projectName)
        {
            return new(Driver, By.XPath($"//*[text()='{projectName}']"));
        }
        public UiElement GetDeleteButtonForProject(string projectName)
        {
            return new(Driver, By.XPath($"//*[text()='{projectName}']/../following-sibling::*//*[@class='icon-small-delete']"));
        }

        public bool ProjectIsDeleted(string projectName)
        {
            return WaitsHelper.WaitForElementInvisible(By.XPath($"//*[text()='{projectName}']"));
        }

        public TRProjectsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }
        protected override bool EvaluateLoadedStatus()
        {
            return ProjectsPageTitle().Displayed;
        }
    }
}
