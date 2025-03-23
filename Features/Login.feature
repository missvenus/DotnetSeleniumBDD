Feature: As a user
I should be able to login the homepage

  Scenario: Valid Login with correct credentials
    Given User is on the home page
    When users enters signin and password
    Then the home page loads
