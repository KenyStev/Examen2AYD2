Feature: Grades
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Calculate Grade
	Given That the student with '21341276' account number
	And These are the following grades
	| AccountNumber | ClassName    | GradeValue | UV |
	| 21341276      | Analisis1    | 88			| 4  |
	| 21341276      | Lenguajes    | 56			| 4  |
	| 21341276      | DisenoLogico | 100		| 3  |
	When I calculate the average grade 
	Then the average grade should be 79.64 on the screen
