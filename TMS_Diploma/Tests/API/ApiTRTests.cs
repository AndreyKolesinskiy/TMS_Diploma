using RestSharp;
using TMS_Diploma.BaseEntities;
using NLog;
using System.Net;
using TMS_Diploma.Models;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace TMS_Diploma.Tests.API
{
    public class ApiTRTests : BaseTest
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        [Category("API_Tests")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("API tests")]
        [AllureDescription("Create new project")]
        public void ApiCreateProject()
        {
            const string endPoint = "/index.php?/api/v2/add_project";

            ApiProjectModel expectedProject = new ApiProjectModel()
            {
                Name = "AKaliasinskiTestProject " + DateTime.Now,
                Announcement = "test",
                IsShowAnnouncement = true,
                ProjectType = 1
            };

            var request = new RestRequest(endPoint).AddJsonBody(expectedProject);

            var response = Client.ExecutePost<ApiProjectModel>(request);
            var actualProject = response.Data;

            _logger.Info(actualProject.Id);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode == HttpStatusCode.OK);
                Assert.That(expectedProject.Equals(actualProject));
            }
            );
        }

        [Test]
        [Category("API_Tests")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("API tests")]
        [AllureDescription("Check data for created project")]
        public void ApiGetCreatedProject()
        {
            const string endpoint = "/index.php?/api/v2/get_project/{project_id}";
            var request = new RestRequest(endpoint).AddUrlSegment("project_id", 450);
            ApiProjectModel expectedProject = new ApiProjectModel()
            {
                Name = "AKaliasinski_Test_Project",
                Announcement = "test",
                IsShowAnnouncement = true,
                ProjectType = 1
            };

            var response = Client.ExecuteGet<ApiProjectModel>(request);
            var actualProject = response.Data;
            _logger.Info(response.Content);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode == HttpStatusCode.OK);
                Assert.That(expectedProject.Equals(actualProject));
            }
            );
        }

        [Test]
        [Category("API_Tests")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("API tests")]
        [AllureDescription("Add new Milestone to existing project")]
        public void ApiAddMilestone()
        {
            const string endPoint = "/index.php?/api/v2/add_milestone/{project_id}";

            ApiMilestoneModel expectedMilestone = new ApiMilestoneModel()
            {
                Name = "AKaliasinski_TestMilestone " + DateTime.Now,
                Description = "Test Milestone description"
            };

            var request = new RestRequest(endPoint).AddUrlSegment("project_id", 450).AddJsonBody(expectedMilestone);

            var response = Client.ExecutePost<ApiMilestoneModel>(request);
            var actualMilestone = response.Data;

            _logger.Info(actualMilestone.Name);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode == HttpStatusCode.OK);
                Assert.That(expectedMilestone.Equals(actualMilestone));
            }
            );
        }

        [Test]
        [Category("API_Tests")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("API tests")]
        [AllureDescription("Check Milestone for existing project")]
        public void ApiGetMilestone()
        {
            const string endpoint = "/index.php?/api/v2/get_milestone/{milestone_id}";
            var request = new RestRequest(endpoint).AddUrlSegment("milestone_id", 12);
            ApiMilestoneModel expectedMilestone = new ApiMilestoneModel()
            {
                Name = "AKaliasinski_TestMilestone_Api",
                Description = "Test Milestone description",
                ProjectId = 450,
                Id = 12
            };

            var response = Client.ExecuteGet<ApiMilestoneModel>(request);
            var actuaMilestone = response.Data;
            _logger.Info(response.Content);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode == HttpStatusCode.OK);
                Assert.That(expectedMilestone.Equals(actuaMilestone));
            }
            );
        }

        [Test]
        [Category("API_Tests")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureSuite("API tests")]
        [AllureDescription("Delete Milestone for existing project")]
        public void ApiDeleteMilestone()
        {
            const string addMilestoneEndPoint = "/index.php?/api/v2/add_milestone/{project_id}";

            ApiMilestoneModel expectedMilestone = new ApiMilestoneModel()
            {
                Name = "AKaliasinski_TestMilestone " + DateTime.Now,
                Description = "Test Milestone description"
            };

            var addRequest = new RestRequest(addMilestoneEndPoint).AddUrlSegment("project_id", 450).AddJsonBody(expectedMilestone);

            var addResponse = Client.ExecutePost<ApiMilestoneModel>(addRequest);
            var milestoneId = addResponse.Data.Id;

            const string deleteMilestoneEndPoint = "/index.php?/api/v2/delete_milestone/{milestone_id}";
            var deleteRequest = new RestRequest(deleteMilestoneEndPoint).AddUrlSegment("milestone_id", milestoneId).AddHeader("Content-Type","application/json");
            var deleteResponse = Client.ExecutePost(deleteRequest);
            _logger.Info(milestoneId);
            _logger.Info(deleteResponse.Content);
            Assert.That(deleteResponse.StatusCode == HttpStatusCode.OK);
        }
    }
}
