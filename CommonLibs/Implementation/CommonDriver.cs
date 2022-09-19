using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Implementation
{
    public class CommonDriver
    {
        public IWebDriver Driver { get; private set; }
        public int PageLoadTimeout { private get => pageLoadTimeout; set => pageLoadTimeout = value; }
        public int ElementDetectionTimeout { private get => elementDetectionTimeout; set => elementDetectionTimeout = value; }

        private int pageLoadTimeout;
        private int elementDetectionTimeout;

        public CommonDriver(string browserType)
        {
            browserType = browserType.Trim();

            pageLoadTimeout = 60;
            elementDetectionTimeout = 10;

            if(browserType.Equals("chrome"))
            {
                Driver = new ChromeDriver();
            } else
            {
                throw new Exception("Invalid browser type " +browserType);
            }
        }

        public void NavigateToFirstUrl(string url)
        {
            url = url.Trim();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);
            Driver.Url = url;
        }

        public void CloseBrower()
        {
            if(Driver != null) Driver.Close();
        }
        
        public void CloseAllBrower()
        {
            if(Driver != null) Driver.Quit();
        }

        public string GetPageTitle()
        {
            return Driver.Title;
        }
    }
}
