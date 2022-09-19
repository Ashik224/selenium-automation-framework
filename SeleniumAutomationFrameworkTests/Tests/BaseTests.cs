using CommonLibs.Implementation;
using NUnit.Framework;
using SeleniumAutomationFrameworkApplication.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFrameworkTests.Tests
{
    public class BaseTests
    {
        public CommonDriver commonDriver;
        readonly string url = "https://demo.guru99.com/v4";

        public LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            commonDriver = new CommonDriver("chrome");
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
