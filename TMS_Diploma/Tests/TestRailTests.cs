using TMS_Diploma.Models;
using TMS_Diploma.Pages;

namespace TMS_Diploma.Tests
{
    [TestFixture]
    public class TestRailTests : BaseTest
    {
        public string projectName;

        [SetUp]
        public void SetUp()
        {
            TRLoginPage.SuccessfulLogin();
        }

        [Test]
        [Category("UI_Tests")]
        public void CreateTestProject()
        {
            TRDashboardPage.AddProjectButton().Click();

            var project = new ProjectModel()
            {
                Name = "AKaliasinskiTestProject " + DateTime.Now,
                Announcement = "Test announcement",
                IsShowAnnouncement = true,
                ProjectType = "Use a single repository for all cases (recommended)",
                IsEnableTestCaseApprovals = true
            };

            projectName = project.Name;
            TRAddProjectPage.NameField().SendKeys(projectName);
            TRAddProjectPage.AnnouncmentField().SendKeys(project.Announcement);
            TRAddProjectPage.SelectShowAnnouncementIfTrue(project.IsShowAnnouncement);
            TRAddProjectPage.SelectPojectType(project.ProjectType);
            TRAddProjectPage.SelectTestCaseApprovalsIfTrue(project.IsEnableTestCaseApprovals);
            TRAddProjectPage.AddProjectSubmitButton().Click();
            Assert.That(TRProjectsPage.GetNewCreatedProjectElement(projectName).Displayed);
        }

        [Test]
        [Category("UI_Tests")]
        public void DeleteTestProject()
        {
            TRDashboardPage.AddProjectButton().Click();
            projectName = "AKaliasinskiTestProject " + DateTime.Now;
            TRAddProjectPage.NameField().SendKeys(projectName);
            TRAddProjectPage.AddProjectSubmitButton().Click();
            TRProjectsPage.GetDeleteButtonForProject(projectName).Click();
            TRProjectsPage.DeleteCheckbox().EnableCheckbox();
            TRProjectsPage.DeleteDialogOKButtton().Click();
            Assert.That(TRProjectsPage.ProjectIsDeleted(projectName), Is.True);
        }
    }
}
