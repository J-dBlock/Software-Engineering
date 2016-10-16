---------------------------------------------
-- Script to create a users and an admin   --
---------------------------------------------

-- Create the Amdin Role
Insert into AspNetRoles(Id, Name)
Values ('1', 'Admin')

-- Run the application to create a user with your email.
-- then this select to get the user id for the account that was created. 
SELECT * FROM PenguinFlightsData.dbo.AspNetUsers


Insert into AspNetUserRoles (UserId, RoleId)
Values ('[paste the Id column value from your user here]', '1')

-- Logged in user will now have hte administrator role associated with their login. 





