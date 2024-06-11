using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Diploma.BaseEntities;
using TMS_Diploma.Element;

namespace TMS_Diploma.Pages
{
    public class TRMilestonesPage : BasePage
    {
        private string _endPoint = "/index.php?/milestones/overview/450";
        public UiElement MilestonesPageTitle() => new(Driver, By.XPath("//*[@data-testid='testCaseContentHeaderTitle']"));
        public UiElement AddMilestoneButton() => new(Driver, By.Id("navigation-milestones-add"));
        public UiElement UploadAttachmentIcon() => new(Driver, By.XPath("//*[@class='icon-markdown-image']"));
        public UiElement AddNewButton() => new(Driver, By.Id("libraryAddAttachment"));
        public UiElement AddedAttachment() => new(Driver, By.XPath("//*[@data-testid='attachmentListItem']"));
        public UiElement AddAttachmentSection() => new(Driver, By.Id("libraryAttachmentsAddItem"));
        public UiElement NewAttachments() => new(Driver, By.Id("newAttachments"));
        public UiElement ElementForFileAttachment() => new(Driver, By.XPath("//div[@id='fancy_overlay']/preceding::input[@type='file']"));
        public IWebElement ElementForUpload() => Driver.FindElement(By.XPath("//div[@id='fancy_overlay']/preceding::input[@type='file']"));

        public override string GetEndpoint()
        {
            return _endPoint;
        }
        protected override bool EvaluateLoadedStatus()
        {
            return MilestonesPageTitle().Displayed;
        }
        public TRMilestonesPage(IWebDriver driver) : base(driver)
        {
        }

    }
}
