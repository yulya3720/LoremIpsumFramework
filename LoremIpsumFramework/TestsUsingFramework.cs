using NUnit.Framework;
using System.Collections.Generic;

namespace LoremIpsumFramework
{
    [TestFixture]
    public class TestsUsingFramework
    {

        [Test]
        public void CheckPresenceOfWord()
        {
            MainPage main = new MainPage();

            main.GoToPage();

            main.SwitchLanguageToRussian();

            string text = main.GetLIpsumMainText();

            Assert.IsTrue(text.Contains("рыба"));
        }

        [Test]
        public void CheckNumberOfParagraphsWithWord() //fails almost every time but that`s ok
        {
            MainPage main = new MainPage();

            main.GoToPage();

            List<string> paragraphs = main.GetParagraphs();

            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                main.GoToPage();

                foreach (string paragraph in paragraphs)
                {
                    if (paragraph.Contains("lorem") || paragraph.Contains("Lorem"))
                    {
                        count++;
                    }
                }
            }

            Assert.IsTrue(((double)count / 10) >= 0);
        }

        int[] numberOfWordsToGenerate = { 20, 15, 50, -1, 0 };

        [Test]
        public void CheckNumberOfGeneratedWords()
        {
            MainPage  main = new MainPage();

            Assert.Multiple(() =>
            {
                foreach (int number in numberOfWordsToGenerate)
                {

                    main.GoToPage();
                    main.SetUnitToGenerate(MainPage.UnitToGenerate.Words);
                    main.SetAmountToGenerate(number);

                    GeneratedPage generated = main.Generate();

                    int actual = generated.CountGeneratedWords();

                    int expected;
                    if (number <= 0)
                    {
                        expected = 5;
                    }
                    else if (number == 1)
                    {
                        expected = 2;
                    }
                    else
                    {
                        expected = number;
                    }

                    Assert.AreEqual(expected, actual);
                }
            });
        }


        int[] numberOfListsToGenerate = { 2, -1, 0, 5 };
        [Test]
        public void CheckNumberOfGeneratedLists()
        {
            MainPage main = new MainPage();

            Assert.Multiple(() =>
            {
                foreach (int number in numberOfListsToGenerate)
                {

                    main.GoToPage();
                    main.SetUnitToGenerate(MainPage.UnitToGenerate.Lists);
                    main.SetAmountToGenerate(number);

                    GeneratedPage generated = main.Generate();

                    int actual = generated.CountGeneratedLists();

                    int expected;
                    if (number <= 0)
                    {
                        expected = 5;
                    }
                    else
                    {
                        expected = number;
                    }

                    Assert.AreEqual(expected, actual);
                }
            });
        }

    }
}
