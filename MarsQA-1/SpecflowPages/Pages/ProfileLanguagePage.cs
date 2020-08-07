using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using static MarsQA_1.Helpers.GenericWait;

namespace MarsQA_1.Pages.ProfileLanguagePage
{
    public class AddProfileLanguage
    {
        private static IWebElement LanguageTab => Driver.driver.FindElement(By.XPath("//a[contains(text(),'Languages')]"));
        private static IWebElement AddNewLanguageButton => Driver.driver.FindElement(By.XPath("//th[contains(text(),'Language')]/..//div[text()='Add New']"));
        private static IWebElement AddLanguage => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static SelectElement ChooseLanguageLevel => new SelectElement(Driver.driver.FindElement(By.Name("level")));
        private static IWebElement AddLanguageButton => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));
        
       private static IWebElement RemoveIcon => Driver.driver.FindElement(By.XPath(LanguageTable + "//i[@class='remove icon']"));
        private static int NumberOfLanguagesFound = 0;
        
        private static string LanguageTable => "//th[contains(text(),'Language')]/../../following-sibling::tbody";
        public static void NavigateToLanguageTab()
        {
            LanguageTab.Click();
        }
        public static void AddNewLanguage(int NumberOfLanguagesToAdd)
        {
            for (int i = 1; i <= NumberOfLanguagesToAdd; i++)
            {
                AddNewLanguageButton.Click();
                ElementIsVisible(Driver.driver, "XPath", "//input[@placeholder='Add Language']", 2);
                ExcelLibHelper.PopulateInCollection(ConstantHelpers.LanguageData, "Language");
                AddLanguage.SendKeys(ExcelLibHelper.ReadData((i+1), "Language"));
                ChooseLanguageLevel.SelectByValue(ExcelLibHelper.ReadData((i+1), "Language Level"));
                AddLanguageButton.Click();
                CommonMethods.MessageValidation("has been added to your languages");
            }
        
        }

        
        public static void SearchLanguage(int NumberOfLanguagesToAdd)
        {

            for (int i = 1; i <= NumberOfLanguagesToAdd; i++)
            {
                ReadOnlyCollection<IWebElement> LanguageRecords = Driver.driver.FindElements(By.XPath(LanguageTable));
                for (int j = 1; j <= LanguageRecords.Count; j++)
                {
                    String LanguageValue = Driver.driver.FindElement(By.XPath(LanguageTable + "[" + j + "]//tr//td[1]")).Text;
                    String LanguageLevelValue = Driver.driver.FindElement(By.XPath(LanguageTable + "[" + j + "]//tr//td[2]")).Text;
                    if (LanguageValue == (ExcelLibHelper.ReadData(i + 1, "Language")) && LanguageLevelValue == (ExcelLibHelper.ReadData(i + 1, "Language Level")))
                    {
                        NumberOfLanguagesFound++;
                        break;
                    }
                }
            }

        }
        public static void SearchLanguageAdded(int NumberOfLanguagesToAdd)
        {
            SearchLanguage(NumberOfLanguagesToAdd);
            Assert.AreEqual(NumberOfLanguagesToAdd, NumberOfLanguagesFound);
        }
        public static void DeleteAllLanguages()
        {
            ReadOnlyCollection<IWebElement> LanguageRecords = Driver.driver.FindElements(By.XPath(LanguageTable));
            for (int i = 0; i < LanguageRecords.Count; i++)
            {
                ElementIsNotVisible(Driver.driver, "ClassName", "ns-box-inner", 2);
                RemoveIcon.Click();
                CommonMethods.MessageValidation("has been deleted from your languages");
            }

        }
        public static void AddNewLanguageButtonNotVisible()
        {
            ReadOnlyCollection<IWebElement> LanguageRecords = Driver.driver.FindElements(By.XPath(LanguageTable));
            if (LanguageRecords.Count == 4)
            {
                try
                {
                    bool Displayed = AddNewLanguageButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    Assert.Pass();
                }
                catch(Exception)
                {
                    Assert.Fail();
                }
            }
        }
        
        
    }
}

