using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsumFramework
{
    class UnitToGeneratePanel
    {
        IWebDriver driver;
        public UnitToGeneratePanel(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.Name, Using = "what")]
        private List<IWebElement> radioButtons;

        public void SetValue(string value)
        {
            foreach(IWebElement radio in radioButtons)
            {

            }
        }
    }
}
