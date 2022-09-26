using AventStack.ExtentReports;
using CommonLibs.Implementation;
using CommonLibs.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using NUnit.Framework;
using SeleniumAutomationFrameworkApplication.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFrameworkTests.Tests
{
    public class BaseTests
    {
        public CommonDriver commonDriver;

        public LoginPage loginPage;

        private IConfigurationRoot _configuration;

        public ExtentReportUtils extentReportUtils;

        string reportFileName;
        string currentSolutionDirectory;

        string url;
        string currentProjectDirectory;

        [OneTimeSetUp]
        public void PreSetup()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            currentSolutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;

            TestContext.Progress.WriteLine("Sol: "+ currentSolutionDirectory);
            reportFileName = currentSolutionDirectory + "/reports/TestReport.html";

            extentReportUtils = new ExtentReportUtils(reportFileName);
            _configuration = new ConfigurationBuilder().AddJsonFile(currentProjectDirectory + "/config/appSettings.json").Build();
        }

        [SetUp]
        public void Setup()
        {
            extentReportUtils.CreateATestCase("Setup");
            string browserType = _configuration["browserType"];
            commonDriver = new CommonDriver(browserType);

            extentReportUtils.AddTestLog(Status.Info, "Browser Type: " + browserType);
            url = _configuration["baseUrl"];
            TestContext.Progress.WriteLine("URL: " + url);
            commonDriver.NavigateToFirstUrl(url);

            loginPage = new LoginPage(commonDriver.Driver);
        }

        [TearDown]
        public void TearDown()
        {
            commonDriver.CloseAllBrower();
        }

        [OneTimeTearDown]
        public void PostCleanup()
        {
            extentReportUtils.FlushReport();
        }
    }
}
