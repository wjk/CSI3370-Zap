Feature: Chatbot

Scenario: Kroger food pick-up interaction
    Given the default test user exists
    And the default test user is logged in
    When the chatbot is loaded
    And action "Food" is selected
    And action "Groceries" is selected
    And action "Kroger" is selected
    And action "PickUp" is selected
    Then the prompt text should be "Sign in or make an account at Kroger.com. During checkout, select pick-up in store during checkout after you have all the items that you want in your cart."
    And the external link "Kroger.com" exists
    
Scenario: Walmart food delivery interaction
    Given the default test user exists
    And the default test user is logged in
    When the chatbot is loaded
    And action "Food" is selected
    And action "Groceries" is selected
    And action "Walmart" is selected
    And action "Deliver" is selected
    Then the prompt text should be "Sign in or make an account at Walmart.com. During checkout, select delivery during checkout after you have all the items that you want in your cart. Be sure to select a good time and date for delivery."
    And the external link "Walmart.com" exists

Scenario: MyRide2 transportation interaction
    Given the default test user exists
    And the default test user is logged in
    When the chatbot is loaded
    And action "Transportation" is selected
    And action "Database" is selected
    Then the prompt text should be "To find transportation services, please enter your ZIP Code in the box that says “Zip Code for Service” and press Search Providers. You will be matched with community and other transportation services in your area. You are then able to choose which service you would like to use."
    And the external link "MyRide2" exists
    
Scenario: TransMedicare transportation interaction
    Given the default test user exists
    And the default test user is logged in
    When the chatbot is loaded
    And action "Transportation" is selected
    And action "LongDistance" is selected
    Then the prompt text should be "For non-emergency medical transportation for distances of 300 miles or more. Click the link and fill out the form on the page, or call the number on the page and set up a time and date for your medical transportation."
    And the external link "TransMedicare" exists
    
Scenario: AngelCaret transportation interaction
    Given the default test user exists
    And the default test user is logged in
    When the chatbot is loaded
    And action "Transportation" is selected
    And action "NonMedical" is selected
    Then the prompt text should be "For non-medical transportation services in the counties of South-eastern Michigan. Fill out the form with the required information to schedule a pickup time and date."
    And the external link "AngelCaret Transportation" exists        
    
