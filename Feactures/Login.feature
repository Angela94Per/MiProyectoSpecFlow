Feature: Login Functionality
  As a registered user
  I want to log in to the system
  So that I can access my contact list

  @login
    Scenario: Login successful with valid credentials
    Given I navigate to the login page
    When I enter valid credentials
    And I click the login button
    Then I should see the main layout loaded

