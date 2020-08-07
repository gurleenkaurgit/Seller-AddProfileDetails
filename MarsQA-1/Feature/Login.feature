Feature: Login
	In order to access the application features
	As a user
	I want to login to the website

@smoke
Scenario: Login to website
	Given I login to the website
	Then  I should be able to see login
