using CommonLibs.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFrameworkTests.Tests
{
    public class HomePageTests
    {
        [Test]
        public void Test1()
        {
            CommonDriver commonDriver = new CommonDriver("chrome");
            commonDriver.NavigateToFirstUrl("https://demoqa.com/");
        }
    }
}
