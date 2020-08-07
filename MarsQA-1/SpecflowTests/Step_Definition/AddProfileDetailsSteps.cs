using System;
using TechTalk.SpecFlow;
using MarsQA_1.Pages.ProfileLanguagePage;
using MarsQA_1.Pages.ProfileSkillsPage;
using MarsQA_1.Helpers;
using System.Security.Cryptography.X509Certificates;
using MarsQA_1.Pages.ProfileCertificationsPage;

namespace MarsQA_1.SpecflowTests.Step_Definition
{
    [Binding]
    public class AddProfileDetailsSteps
    {

        [Given(@"I navigate to Profile details page")]
        public void GivenINavigateToProfileDetailsPage()
        {

            Driver.NavigateToProfilePage();
        }

        [Given(@"I navigate to Langugae Tab")]
        public void GivenINavigateToLangugaeTab()
        {
            AddProfileLanguage.NavigateToLanguageTab();
        }

        [Given(@"No existing Langugae is present")]
        public void GivenNoExistingLangugaeIsPresent()
        {
            AddProfileLanguage.DeleteAllLanguages();
        }



        [When(@"I add (.*) Language LanguageLevel")]
        public void WhenIAddLanguageLanguageLevel(int NumberOfLanguagesToAdd)
        {
            AddProfileLanguage.AddNewLanguage(NumberOfLanguagesToAdd);
        }
        [Then(@"I should be able to add (.*) Language with LanguageLevel")]
        public void ThenIShouldBeAbleToAddLanguageWithLanguageLevel(int NumberOfLanguagesToAdd)
        {
            AddProfileLanguage.SearchLanguageAdded(NumberOfLanguagesToAdd);

        }


        [Then(@"Add New button is not visible to add more language")]
        public void ThenAddNewButtonIsNotVisibleToAddMoreLanguage()
        {
            AddProfileLanguage.AddNewLanguageButtonNotVisible();


        }

        [Given(@"I navigate to Skills Tab")]
        public void GivenINavigateToSkillsTab()
        {
            AddProfileSkill.NavigateToSkillsTab();
        }

        [Given(@"An existing skill is present if not add '(.*)' with '(.*)'")]
        public void GivenAnExistingSkillIsPresentIfNotAddWith(string Skill, string SkillLevel,Table table)
        {
            AddProfileSkill.CheckExistingSkillIsPresent(Skill, SkillLevel);
        }

        public string Skill;
        public string SkillLevel;
        [When(@"I Edit an existing Skill for Seller Profile")]
        public void WhenIEditAnExistingSkillForSellerProfile()
        {
            
            AddProfileSkill.UpdateSkill( out string UpdatedSkill, out string UpdatedSkillLevel);
            this.Skill = UpdatedSkill;
            this.SkillLevel = UpdatedSkillLevel;
        }
        
        [Then(@"I should be able to edit an existing skill")]
        public void ThenIShouldBeAbleToEditAnExistingSkill()
        {
           
            AddProfileSkill.SearchSkillUpdated(Skill, SkillLevel);
        }

        [Given(@"I navigate to Certifications Tab")]
        public void GivenINavigateToCertificationsTab()
        {
            ProfileCertificationPage.NavigateToCertificationsTab();
        }
        [Given(@"An existing Certification is present")]
        public void GivenAnExistingCertificationIsPresent()
        {
            ProfileCertificationPage.CheckExistingCertificationIsPresent();
        }
        public string Certification;
        public string From;
        public int Year;
        [When(@"I delete an existing Certification for Seller Profile")]
        public void WhenIDeleteAnExistingCertificationForSellerProfile()
        {
            ProfileCertificationPage.DeleteCertification(out string DeletedCertification, out string DeletedFrom, out int DeletedYear);
                this.Certification = DeletedCertification;
            this.From = DeletedFrom;
            this.Year = DeletedYear;
        }
        [Then(@"I should be able to delete an existing Certification")]
        public void ThenIShouldBeAbleToDeleteAnExistingCertification()
        {
           
            ProfileCertificationPage.SearchCertificationDeleted(Certification, From, Year);

        }

    }
}

        