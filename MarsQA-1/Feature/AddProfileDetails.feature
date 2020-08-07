Feature: AddProfileDetails
	As a Seller
	I want the feature to add my Profile Details
	So that
	The people seeking for some skills can look into my details.

	Background: 
	Given I navigate to Profile details page

@Regression 
Scenario: Add 4 languages to Seller Profile 
	Given I navigate to Langugae Tab
	And No existing Langugae is present 
	When I add 4 Language LanguageLevel
	Then I should be able to add 4 Language with LanguageLevel
	And Add New button is not visible to add more language
	

@Regression
	Scenario: Update an existing Skill to Seller Profile
	Given I navigate to Skills Tab
	And  An existing skill is present if not add '<Skill>' with '<Skill Level>'
	| Skill | Skill Level  |
	| C#    | Intermediate |
	When I Edit an existing Skill for Seller Profile
	Then I should be able to edit an existing skill 

	@Regression
	Scenario: Delete an existing Certification to Seller Profile
	Given I navigate to Certifications Tab
	And  An existing Certification is present
	When I delete an existing Certification for Seller Profile
	Then I should be able to delete an existing Certification 