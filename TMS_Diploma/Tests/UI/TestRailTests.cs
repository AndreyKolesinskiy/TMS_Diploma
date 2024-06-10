using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using System.Reflection;
using TMS_Diploma.BaseEntities;
using TMS_Diploma.Models;
using TMS_Diploma.Pages;

namespace TMS_Diploma.Tests.UI
{
    [TestFixture]
    public class TestRailTests : BaseTest
    {
        [Test]
        [Category("UI_Tests")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("UI tests")]
        [AllureDescription("Create new project")]
        public void CreateTestProject()
        {
            TRLoginPage.SuccessfulLogin();
            TRDashboardPage.AddProjectButton().Click();

            var project = new ProjectModel()
            {
                Name = "AKaliasinskiTestProject " + DateTime.Now,
                Announcement = "Test announcement",
                IsShowAnnouncement = true,
                ProjectType = "Use a single repository for all cases (recommended)",
                IsEnableTestCaseApprovals = true
            };

            var projectName = project.Name;
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
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("UI tests")]
        [AllureDescription("Delete existing project")]
        public void DeleteTestProject()
        {
            TRLoginPage.SuccessfulLogin();
            TRDashboardPage.AddProjectButton().Click();
            var projectName = "AKaliasinskiTestProject " + DateTime.Now;
            TRAddProjectPage.NameField().SendKeys(projectName);
            TRAddProjectPage.AddProjectSubmitButton().Click();
            TRProjectsPage.GetDeleteButtonForProject(projectName).Click();
            TRProjectsPage.DeleteCheckbox().EnableCheckbox();
            TRProjectsPage.DeleteDialogOKButtton().Click();
            Assert.That(TRProjectsPage.ProjectIsDeleted(projectName), Is.True);
            Assert.Multiple(() =>
            {
                Assert.That(TRProjectsPage.DeletedProjectSuccessMessage().Text,
                    Is.EqualTo("Successfully deleted the project."));
                Assert.That(TRProjectsPage.ProjectIsDeleted(projectName), Is.True);
            }
            );
        }

        [Test]
        [Category("UI_Tests")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSuite("UI tests")]
        [AllureDescription("Login with invalid credentials and check error message")]
        public void LoginWithInvalidCredentials()
        {
            TRLoginPage.OpenPageByUrl();
            TRLoginPage.EmailField().SendKeys("Tets_User");
            TRLoginPage.PasswordField().SendKeys("Tets_Password");
            TRLoginPage.LogInButton().Click();
            Assert.That(TRLoginPage.IncorrectCredentialsErrorMessage().Text, 
                Is.EqualTo("Email/Login or Password is incorrect. Please try again."));
        }

        [Test]
        [Category("UI_Tests")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSuite("UI tests")]
        [AllureDescription("Login failing test to shown attachments in Allure report")]
        public void FailingTest()
        {
            TRLoginPage.OpenPageByUrl();
            TRLoginPage.EmailField().SendKeys("Tets_User");
            TRLoginPage.PasswordField().SendKeys("Tets_Password");
            TRLoginPage.LogInButton().Click();
            Assert.That(TRLoginPage.IncorrectCredentialsErrorMessage().Text,
                Is.EqualTo("Wrong error message text"));
        }

        [Test]
        [Category("UI_Tests")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSuite("UI tests")]
        [AllureDescription("Upload attachement to Milestone")]
        public void UploadAttachmentToMilestone()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources",
            "TestTextFile.txt");
            TRLoginPage.SuccessfulLogin();
            TRMilestonesPage.OpenPageByUrl();
            TRMilestonesPage.AddMilestoneButton().Click();
            TRMilestonesPage.ElementForUpload().SendKeys(filePath);
            
            Assert.That(TRMilestonesPage.AddedAttachment().Displayed);
        }
    }
}
