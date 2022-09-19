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
            loginPage.LoginToApplication("mngr288890", "sutydum");

            string expectedTitle = "Guru99 Bank Home Page";
            string actualTitle = commonDriver.GetPageTitle();
            Assert.AreEqual(expectedTitle, actualTitle, "Title didn't match!");
        }
    }
}
