using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFrameworkApplication.Pages
{
    public class LoginPage : BasePage
    {
        private IWebDriver _driver;
        private IWebElement username => _driver.FindElement(By.Name("uid"));
        private IWebElement password => _driver.FindElement(By.Name("password"));
        private IWebElement loginButton => _driver.FindElement(By.Name("btnLogin"));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void LoginToApplication(string sUsername, string sPassword)
        {
            commonElement.SetText(username, sUsername);
            commonElement.SetText(password, sPassword);
            commonElement.ClickElement(loginButton);
        }
    }
}
