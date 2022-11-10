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
