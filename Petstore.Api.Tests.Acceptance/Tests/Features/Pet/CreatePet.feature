Feature: CreatePet

Verifies a new pet can be added to the store.

@createPet
Scenario: Can add a new pet to the store successfully
	When I create a pet with the following details
	| Name | Status  |
	| BuBu | pending |
	Then Http status code should be OK
	And I can see new pet is created successfully

@createPet
Scenario: Cannot add a new pet without required properties
	When I create a pet without the required details
	Then Http status code should be MethodNotAllowed