Feature: Sign in page

Scenario: Successful login
	Given the default test user exists
	And the login page is loaded
	And the email address is "testuser@example.com"
	And the password is "testuser"
	When the login is submitted
	Then the user should be logged in
	
Scenario: Unknown username
    Given the default test user exists
    And the login page is loaded
    And the email address is "doesnotexist@example.com"
    And the password is "notfound"
    When the login is submitted
    Then the login should fail
    
Scenario: Incorrect password
    Given the default test user exists
    And the login page is loaded
    And the email address is "testuser@example.com"
    And the password is "incorrect"
    When the login is submitted
    Then the login should fail
