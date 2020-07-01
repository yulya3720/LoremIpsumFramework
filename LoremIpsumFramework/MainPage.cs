using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace LoremIpsumFramework
{
    public class MainPage
    {

        IWebDriver driver;
        public MainPage()
        {
            driver = new ChromeDriver();
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Languages\"]/a[@class=\"ru\"]")]
        private IWebElement russianButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Panes\"]/div[1]/p")]
        private IWebElement lIpsumMainText;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"amount\"]")]
        private IWebElement amountToGenerateField;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"paras\"]")]
        private IWebElement paragraphsToGenerateRadio;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"words\"]")]
        private IWebElement wordsToGenerateRadio;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"bytes\"]")]
        private IWebElement bytesToGenerateRadio;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"lists\"]")]
        private IWebElement listsToGenerateRadio;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"generate\"]")]
        private IWebElement generateButton;

        [FindsBy(How = How.CssSelector, Using = "#lipsum p")]
        private IList<IWebElement> paragraphList;

        public enum UnitToGenerate
        {
            Paragraphs,
            Words,
            Bytes,
            Lists
        };

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("https://lipsum.com/");
        }

        public void SwitchLanguageToRussian()
        {
            russianButton.Click();
        }

        public string GetLIpsumMainText()
        {
            return lIpsumMainText.Text;
        }

        public List<string> GetParagraphs()
        {
            List<string> paragraphsTextList = new List<string>();

            foreach(IWebElement paragraph in paragraphList)
            {
                paragraphsTextList.Add(paragraph.Text);
            }
            return paragraphsTextList;
        }
        public void SetAmountToGenerate(object number)
        {
            amountToGenerateField.Clear();
            amountToGenerateField.SendKeys(number.ToString());
        }

        public void SetUnitToGenerate(UnitToGenerate unit)
        {
            if (unit == UnitToGenerate.Paragraphs)
            {
                paragraphsToGenerateRadio.Click();
            }
            else if (unit == UnitToGenerate.Words)
            {
                wordsToGenerateRadio.Click();
            }
            else if (unit == UnitToGenerate.Bytes)
            {
                bytesToGenerateRadio.Click();
            }
            else if (unit == UnitToGenerate.Lists)
            {
                listsToGenerateRadio.Click();
            }
        }

        public GeneratedPage Generate()
        {
            ScrollToElement(generateButton);
            generateButton.Click();
            GeneratedPage generated = new GeneratedPage(driver);
            return generated;
        }
         
        public void Generate(UnitToGenerate unitToGenerate, int amount)
        {
            SetUnitToGenerate(unitToGenerate);
            SetAmountToGenerate(amount);
            Generate();
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", generateButton);
        }

        [TearDown]
        public void CloseWindow()
        {
            driver.Close();
        }
    }
}
