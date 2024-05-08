Feature: CreatePet

Verifies a new pet can be added to the store.

@createPet
Scenario: Can add a new pet to the store successfully
	When I create a pet with the following details
	| Name | Status  |
	| BuBu | pending |
	Then Http status code should be OK
	And I can see new pet is created successfully
