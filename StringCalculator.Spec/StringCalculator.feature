Feature: StringCalculator
	As a math idiot
	I want to be told the sum of two numbers
	In order to avoid silly mistakes	
	
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Add three numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	And I have entered 80 into the calculator
	When I press add
	Then the result should be 200 on the screen

Scenario: Add five numbers
	Given I have entered
	| numbers |
	| 12      |
	| 32      |
	| 23      |
	| 87      |
	| 90      |
	When I press add
	Then the result should be 244 on the screen

