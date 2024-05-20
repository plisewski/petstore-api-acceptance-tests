Feature: GetPetById

Verifies getting pet from the store.

Scenario: Can get existing pet from the store successfully
	Given A pet with the following details exist in the store
	| Name | Status  |
	| BuBu | pending |
	When I get existing pet from the store
	Then Http status code should be OK
	And Existing pet is getting successfully
