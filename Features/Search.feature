Feature: Amazon Search Functionality
    As a Guest User
    I want to search for a product on Amazon
    So that I can see relevant search results

    Scenario: Search for a valid product
        Given User is on the Amazon homepage
        When User searches for "Laptop"
        Then Search results for "Laptop" should be displayed