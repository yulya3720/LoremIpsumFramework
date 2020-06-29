using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LoremIpsum2Task1
{
    [TestFixture]
    class Task2
    {

        string[] numberOfWords = {"20", "15", "50", "-1", "0"};
        [Test]
        public void GenerateNWords()
        {
            IWebDriver driver = new ChromeDriver();
;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            foreach (string number in numberOfWords)
            {

                driver.Navigate().GoToUrl("https://lipsum.com/");

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='words']")));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#amount")));

                driver.FindElement(By.XPath("//input[@id='words']")).Click();
                driver.FindElement(By.CssSelector("#amount")).Clear();
                driver.FindElement(By.CssSelector("#amount")).SendKeys(number);

                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#generate")));

                IWebElement generateButton = driver.FindElement(By.CssSelector("#generate"));

                js.ExecuteScript("arguments[0].scrollIntoView();", generateButton);

                generateButton.Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#lipsum p")));

                string paragraph = driver.FindElement(By.CssSelector("#lipsum p")).Text;
                string[] words = paragraph.Split(' ');

                bool flag = false;

                if (Convert.ToInt32(number) <= 0 && words.Length == 5)
                {
                    flag = true;
                } 
                else if (Convert.ToInt32(number) == 1 && words.Length == 2)
                {
                    flag = true;
                } 
                else if(Convert.ToInt32(number) > 1 && words.Length == Convert.ToInt32(number))
                {
                    flag = true;
                }

                Assert.IsTrue(flag);
            }

            driver.Close();

        }

    }
}
