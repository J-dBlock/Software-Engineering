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
Values ('a567b817-8d9d-48df-8ac1-657d0049f797', '1')

-- Logged in user will now have hte administrator role associated with their login. 

Select f.Name,
		a.City, a.Country, a2.City, a2.Country from Flights f
Join Airports a on f.DestinationAirportId = a.Id
Join Airports a2 on f.SourceAirportId = a2.Id


Select a.Id, a.Name, a.Country from Airports a
where a.Country Like 'United States' and (a.City like '%Paul' or 
	a.City like '%Minn')

 
 Select * from Flights



