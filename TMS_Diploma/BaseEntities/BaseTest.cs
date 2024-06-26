﻿using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using NLog;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.Reflection;
using TMS_Diploma.Core;
using TMS_Diploma.Pages;
using TMS_Diploma.Utils;

namespace TMS_Diploma.BaseEntities
{
    //[Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    //[TestFixture]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        //[OneTimeSetUp]
        //[AllureBefore("Clean up allure-results directory")]
        //public static void GlobalSetup()
        //{
        //    AllureLifecycle.Instance.CleanupResultDirectory();
        //}

        protected Logger logger = LogManager.GetCurrentClassLogger();
        public IWebDriver Driver { get; set; }
        public WaitsHelper? WaitsHelper { get; set; }
        public Actions Actions { get; set; }
        public TRLoginPage TRLoginPage { get; set; }
        public TRDashboardPage TRDashboardPage { get; set; }
        public TRAddProjectPage TRAddProjectPage { get; set; }
        public TRProjectsPage TRProjectsPage { get; set; }
        public TRMilestonesPage TRMilestonesPage { get; set; }

        [SetUp]
        [AllureBefore("Setup driver")]
        public void SetUp()
        {
            Driver = new Browser().Driver;
            WaitsHelper = new WaitsHelper(Driver);
            Actions = new Actions(Driver);
            TRLoginPage = new TRLoginPage(Driver);
            TRDashboardPage = new TRDashboardPage(Driver);
            TRAddProjectPage = new TRAddProjectPage(Driver);
            TRProjectsPage = new TRProjectsPage(Driver);
            TRMilestonesPage = new TRMilestonesPage(Driver);
        }

        [TearDown]
        [AllureAfter("Driver quit")]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var screenshotByte = screenshot.AsByteArray;
                AllureApi.AddAttachment("screenshot", "image/png", screenshotByte);
            }
            Driver.Close();
            Driver.Quit();

        }
    }
}
