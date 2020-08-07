using Google.Protobuf.WellKnownTypes;
using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsQA_1.Helpers.GenericWait;


namespace MarsQA_1.Pages.ProfileSkillsPage
{
   public class AddProfileSkill
    {
        private static IWebElement SkillsTab => Driver.driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
        private static IWebElement AddNewSkillButton => Driver.driver.FindElement(By.XPath("//th[contains(text(),'Skill')]/..//div[text()='Add New']"));
        private static IWebElement AddSkill => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private static SelectElement ChooseSkillLevel => new SelectElement(Driver.driver.FindElement(By.Name("level")));
        private static IWebElement AddSkillButton => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));
        private static IWebElement EditIcon => Driver.driver.FindElement(By.XPath(SkillTable+"//i[@class='outline write icon']"));
        private static IWebElement UpdateButton => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));
        private static string SkillTable => "//th[contains(text(),'Skill')]/../../following-sibling::tbody";

        private static bool FoundSkill = false;
        public static void NavigateToSkillsTab()
        {
            SkillsTab.Click();

           
        }

        public static void CheckExistingSkillIsPresent(string Skill, string SkillLevel)
            
        {
            int Skillrecords = (Driver.driver.FindElements(By.XPath(SkillTable))).Count;
            if (Skillrecords < 1)
            {
                AddNewSkill(Skill, SkillLevel);
            }
        }
        public static void AddNewSkill(string Skill, string SkillLevel)
        {
            AddNewSkillButton.Click();
            ElementIsVisible(Driver.driver, "XPath", "//input[@placeholder='Add Skill']", 2);
            AddSkill.SendKeys(Skill);
            ChooseSkillLevel.SelectByValue(SkillLevel);
            AddSkillButton.Click();
            CommonMethods.MessageValidation("has been added to your skills");
        }
        public static void UpdateSkill(out string UpdatedAddSkill, out string SkillLevelUpdate)
        {
            EditIcon.Click();
            ElementIsVisible(Driver.driver, "XPath", "//input[@placeholder='Add Skill']", 2);
            AddSkill.SendKeys("Updated");
            UpdatedAddSkill = AddSkill.GetAttribute("Value")+ "Updated";
            SkillLevelUpdate = "Null";
            ReadOnlyCollection<IWebElement> AllOptions = (ReadOnlyCollection<IWebElement>)ChooseSkillLevel.Options;
            foreach (IWebElement SkillLevel in AllOptions)
            {
                bool CheckSkill = SkillLevel.Selected;
                if (CheckSkill == false && SkillLevel.Text != "Skill Level")
                {
                    SkillLevelUpdate = SkillLevel.Text;
                    break;
                }
            }
            ChooseSkillLevel.SelectByText(SkillLevelUpdate);
            
            UpdateButton.Click();
            CommonMethods.MessageValidation("has been updated to your skills");

        }

        
        public static void SearchSkill(string SKill, string SkillLevel)
        {
            ReadOnlyCollection<IWebElement> SkillRecords = Driver.driver.FindElements(By.XPath(SkillTable));
            for (int i = 1; i <= SkillRecords.Count; i++)
            {
                String SkillValue = Driver.driver.FindElement(By.XPath(SkillTable+"[" + i + "]//tr//td[1]")).Text;
                String SkillLevelValue = Driver.driver.FindElement(By.XPath(SkillTable+"[" + i + "]//tr//td[2]")).Text;
                if (SkillValue == SKill && SkillLevelValue == SkillLevel)
                {
                    FoundSkill = true;
                    break;
                }
            }

        }
        public static void SearchSkillUpdated(String SKill, String SkillLevel)
        {
            SearchSkill(SKill, SkillLevel);
            Assert.IsTrue(FoundSkill);
        }
    }

}
