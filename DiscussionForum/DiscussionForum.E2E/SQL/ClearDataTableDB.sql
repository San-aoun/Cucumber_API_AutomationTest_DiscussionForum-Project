--------------Set variable with multiple values to Table ------

declare @Email table(Value varchar(100))
insert into @Email values ('qa_automation_api_01@test.com')
insert into @Email values ('qa_automation_api_02@test.com')
insert into @Email values ('qa_automation_api_03@test.com')

declare @ReferenceId table(Value varchar(100))
insert into @ReferenceId values ('TAR001')
insert into @ReferenceId values ('TAR002')
insert into @ReferenceId values ('TAR003')
insert into @ReferenceId values ('TAR004')
insert into @ReferenceId values ('TAR005')
insert into @ReferenceId values ('AutomateTest\TAR001')
insert into @ReferenceId values ('AutomateTest\TAR002')
insert into @ReferenceId values ('AutomateTest\TAR003')

--------------------- Clear data test -------------------------

DELETE U
  FROM UserAccounts U
  LEFT JOIN Accounts A ON U.AccountId = A.Id
 WHERE ReferenceId in (select value from @ReferenceId);

DELETE S
  FROM Subscriptions S
  LEFT JOIN Accounts A ON S.AccountId = A.Id
 WHERE ReferenceId in (select value from @ReferenceId);

DELETE FROM Users 
	where Email in (select value from @Email);

DELETE R
  FROM ResourceGroups R
  LEFT JOIN Accounts A ON R.AccountId = A.Id
 WHERE ReferenceId in (select value from @ReferenceId);

DELETE P
  FROM PaymentDetails P
  LEFT JOIN Accounts A ON P.AccountId = A.Id
	WHERE ReferenceId in (select value from @ReferenceId);

DELETE FROM Accounts 
	WHERE ReferenceId in (select value from @ReferenceId);


