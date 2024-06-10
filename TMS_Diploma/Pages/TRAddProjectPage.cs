using OpenQA.Selenium;
using TMS_Diploma.BaseEntities;
using TMS_Diploma.Element;

namespace TMS_Diploma.Pages
{
    public class TRAddProjectPage : BasePage
    {
        private string _endPoint = "index.php?/admin/projects/add/1";
        public UiElement NameField() => new(Driver, By.Id("name"));
        public UiElement AnnouncmentField() => new(Driver, By.Id("announcement_display"));
        public Checkbox ShowTheAnnouncementCheckbox() => new(Driver, By.Id("show_announcement"));
        public Checkbox EnableTestCaseApprovalsCheckbox() => new(Driver, By.Id("case_statuses_enabled"));
        public RadioButton ProjectTypeRadioButtons() => new(Driver, By.XPath("//*[@name='suite_mode']"));
        public UiElement AddProjectSubmitButton() => new(Driver, By.Id("accept"));

        public TRAddProjectPage(IWebDriver driver) : base(driver)
        {
        }

        public void SelectShowAnnouncementIfTrue(bool showAnnouncement)
        {
            if (showAnnouncement)
                ShowTheAnnouncementCheckbox().EnableCheckbox();
        }

        public void SelectTestCaseApprovalsIfTrue(bool testCaseApprovals)
        {
            if (testCaseApprovals)
                EnableTestCaseApprovalsCheckbox().EnableCheckbox();
        }

        public void SelectPojectType(string pojectType)
        {
            ProjectTypeRadioButtons().SelectByText(pojectType);
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return NameField().Displayed;
        }
    }
}
