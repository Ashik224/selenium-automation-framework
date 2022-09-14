using CommonLibs.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFrameworkApplication.Pages
{
    public class BasePage
    {
        public CommonElement commonElement;

        public BasePage()
        {
            commonElement = new CommonElement();
        }
    }
}
