Feature: Create New User


Background: 
	Given navigate the registeration website

####################################################
# Validation of Functional
####################################################
Scenario: User create new account with correct infomation should create account	
	When user creates with new account with data details:
		| Email         | Password   | Confirm Password |
		| Test@test.com | TTT_ttt123 | TTT_ttt123       |  
	Then User can create data and go to page User detail with the message "Welcome"
	And database create with infomation
		| Email         |
		| Test@test.com |  

####################################################
# Invalidation of Functional
####################################################
Scenario: User create new account with invalid infoation should display error
	When user creates with new account with data details:
		| Email         | Password   | Confirm Password |
		| Test@test.com | TTT_ttt123 | test             |  
	Then display error message "Error message"

