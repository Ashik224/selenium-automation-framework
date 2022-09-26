using AventStack.ExtentReports;
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
    public class LoginPageTests : BaseTests
    {
        [Test]
        public void VerifyLoginTest()
        {
            extentReportUtils.CreateATestCase("Verify Login Test");
            extentReportUtils.AddTestLog(Status.Info, "Performing login");
            loginPage.LoginToApplication("mngr442936", "YrAtynY");

            string expectedTitle = "Guru99 Bank Manage HomePage";
            string actualTitle = commonDriver.GetPageTitle();
            Assert.AreEqual(expectedTitle, actualTitle, "Title didn't match!");
        }
    }
}
