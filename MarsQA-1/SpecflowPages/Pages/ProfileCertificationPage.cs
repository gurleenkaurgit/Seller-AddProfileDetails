using MarsQA_1.Helpers;
using MongoDB.Bson;
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

namespace MarsQA_1.Pages.ProfileCertificationsPage
{
    public class ProfileCertificationPage
    {
        private static IWebElement CertificationsTab => Driver.driver.FindElement(By.XPath("//a[contains(text(),'Certifications')]"));
        private static IWebElement AddNewCertificationButton => Driver.driver.FindElement(By.XPath("//th[contains(text(),'Certificate')]/..//div[text()='Add New']"));
        private static IWebElement CertificationName => Driver.driver.FindElement(By.Name("certificationName"));
        private static IWebElement CertificationFrom => Driver.driver.FindElement(By.Name("certificationFrom"));
        private static SelectElement CertificationYear => new SelectElement(Driver.driver.FindElement(By.Name("certificationYear")));
        private static IWebElement AddCertificationButton => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));
       
        private static IWebElement RemoveIcon => Driver.driver.FindElement(By.XPath(CertificateTable+"//i[@class='remove icon']"));
        private static bool FoundSkill = false;
        private static string CertificateTable => "//th[contains(text(),'Certificate')]/../../following-sibling::tbody";
        public static void NavigateToCertificationsTab()
        {
            CertificationsTab.Click();

        }
        public static void CheckExistingCertificationIsPresent()
        {
            int Certificationrecords = (Driver.driver.FindElements(By.XPath(CertificateTable))).Count;
            if (Certificationrecords < 1)
            {
                AddNewCertification();           
            }
        }
        public static void AddNewCertification()
        {
            AddNewCertificationButton.Click();
            ElementIsVisible(Driver.driver, "Name", "certificationName", 2);
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.CertificationsData, "Certifications");
            CertificationName.SendKeys(ExcelLibHelper.ReadData(2, "CertificationName"));
            CertificationFrom.SendKeys(ExcelLibHelper.ReadData(2, "CertificationFrom"));
            CertificationYear.SelectByValue(ExcelLibHelper.ReadData(2, "CertificationYear"));
            AddCertificationButton.Click();
            CommonMethods.MessageValidation("has been added to your certification");
        }
        
        public static void DeleteCertification(out string Certification, out string From, out int Year)
        {
            
            IWebElement CertificationRecords = Driver.driver.FindElement(By.XPath(CertificateTable + "/tr"));
            Certification = CertificationRecords.FindElement(By.XPath(CertificateTable+"/tr/td[1]")).Text;
            From = CertificationRecords.FindElement(By.XPath(CertificateTable+"/tr/td[2]")).Text;
            Year = int.Parse(CertificationRecords.FindElement(By.XPath(CertificateTable+"/tr/td[3]")).Text);
            ElementIsNotVisible(Driver.driver, "ClassName", "ns-box-inner", 2);
            RemoveIcon.Click();
            CommonMethods.MessageValidation("has been deleted from your certification");
        }
        public static void SearchCertification(string Certification, string From,int Year)
        {
            ReadOnlyCollection<IWebElement> CertificationRecords = Driver.driver.FindElements(By.XPath(CertificateTable));
            for (int i = 1; i <= CertificationRecords.Count; i++)
            {
                String CertificationValue = Driver.driver.FindElement(By.XPath(CertificateTable+"[" + i + "]//tr//td[1]")).Text;
                String FromValue = Driver.driver.FindElement(By.XPath(CertificateTable+"[" + i + "]//tr//td[2]")).Text;
                int YearValue = int.Parse(Driver.driver.FindElement(By.XPath(CertificateTable+"[" + i + "]//tr//td[3]")).Text);
                if (CertificationValue == Certification && FromValue == From && YearValue== Year)
                {
                    FoundSkill = true;
                    break;
                }
            }

        }
        public static void SearchCertificationDeleted(string Certification, string From, int Year)
        {
            SearchCertification(Certification, From, Year);
            Assert.IsFalse(FoundSkill);
        }
    }
}
