using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Utilities
{
    public class ExtentReportUtils
    {
        private ExtentHtmlReporter extentHtmlReporter;
        private ExtentReports extentReports;
        private ExtentTest extentTest;

        public ExtentReportUtils(string htmlReportFileName)
        {
            extentHtmlReporter = new ExtentHtmlReporter(htmlReportFileName);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        public void CreateATestCase(string testCaseName)
        {
            extentTest = extentReports.CreateTest(testCaseName);
        }

        public void AddTestLog(Status status, string comment)
        {
            extentTest.Log(status, comment);
        }

        public void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
