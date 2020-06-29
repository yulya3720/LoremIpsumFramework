using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoremIpsumFramework
{
    public class GeneratedPage
    {
        IWebDriver driver;
        public GeneratedPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"lipsum\"]")]
        private IWebElement generatedText;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"lipsum\"]/ul")]
        private IList<IWebElement> generatedLists; 


        public string GetGeneratedText()
        {
            return generatedText.Text;
        }

        public int CountGeneratedWords()
        {
            string[] words = GetGeneratedText().Split(' ');
            return words.Length;
        }

        public int CountGeneratedLists()
        {
            return generatedLists.Count;
        }
    }
}
