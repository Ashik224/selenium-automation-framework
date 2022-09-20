using CommonLibs.Implementation;
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

        string url;
        string currentProjectDirectory;

        [OneTimeSetUp]
        public void PreSetup()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            _configuration = new ConfigurationBuilder().AddJsonFile(currentProjectDirectory + "/config/appSettings.json").Build();
        }

        [SetUp]
        public void Setup()
        {
            string browserType = _configuration["browserType"];
            commonDriver = new CommonDriver(browserType);

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
    }
}
