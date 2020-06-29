//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoremIpsum2Tasks
{
    //[TestClass()]
    [TestFixture]
    public class Tasks
    {
       //[TestMethod()]
       [Test]
        public void CheckPresenceOfWord()
        {
            
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);//explicit

            driver.Navigate().GoToUrl("https://lipsum.com/");

            driver.FindElement(By.XPath("//*[@id='Languages']/a[contains(@class, 'ru')]")).Click();////*[@id='Languages']//a[contains(@class, 'ru') and text()='Pyccкий']

            string paragraph1 = driver.FindElement(By.XPath("//*[@id=\"Panes\"]/div[1]/p[1]")).Text; 

          
            driver.Close();
            Assert.IsTrue(paragraph1.Contains("рыба"));
        }

        // [TestMethod()]
        [Test]
        public void CheckNumberOfParagraphsWithWord()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);//explicit

            int counter = 0;
            driver.Navigate().GoToUrl("https://lipsum.com/");
            for (int i = 0; i < 10; i++)
            {
                // driver.Navigate().GoToUrl("https://lipsum.com/");
                
                driver.FindElement(By.CssSelector("#generate")).Click();

                List<IWebElement> paragraphsList = driver.FindElements(By.CssSelector("#lipsum p")).ToList();

                foreach (IWebElement paragraph in paragraphsList)
                {
                    if (paragraph.Text.Contains("lorem") || paragraph.Text.Contains("Lorem"))
                    {
                        counter++;
                    }
               
                } 
                driver.Navigate().Back();
            }

            driver.Close();
            Assert.IsTrue(((double)counter/10) >= 3);

        }
    }
}
