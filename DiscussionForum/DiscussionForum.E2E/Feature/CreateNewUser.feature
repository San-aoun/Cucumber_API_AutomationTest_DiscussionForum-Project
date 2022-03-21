Feature: Create New User


Background: 
	Given navigate the registeration website

####################################################
# Validation of Functional
####################################################
Scenario: User create new account with correct infomation should create account	
	When user creates with new account with data details:
		| Data             | Value         |
		| Email            | Test@test.com |
		| Password         | TTT_ttt123    |
		| Confirm Password | TTT_ttt123    |  
	Then User can create data and go to page User detail
	And database create with infomation
		| Email         |
		| Test@test.com |  

####################################################
# Invalidation of Functional
####################################################
Scenario: User create new account with invalid infoation should display error
#	When user creates with new account with data details:
#		| Data             | Value               |
#		| Email            | <Email>             |
#		| Password         | <Password>          |
#		| Confirm Password | <Confirm Password > |  
#	Then display error message "Error message"
#
#	Examples: 
#	| Case                           | Email         | Password   | Confirm Password | Error message           |
#	| Confirm passoword incorrect    | Test@test.com | TTT_ttt123 | test             | Wrong password          |
#	| Confirm password is not safety | Test@test.com | test       | test             | Please, Create Password |

