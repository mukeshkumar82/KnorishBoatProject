# KnorishBoatProject
Boat Assignmentprovided by Knorish company

# Assignment Link: 
https://docs.google.com/document/d/1sZ3xwgJ_SCgHPGg-gSdeeovvAdXyHD8irVVQsOnis-o/edit

# Technical Requirements:
.Net Core with C# has been selected to create WebAPI so that we can get inbuilt feature of DI and also API can be deployed on different other OS apart from Windows only. To save data I use SQL Server database.

# Flow:
There are two action methods (RegisterBoat and BookBoat) in WebAPI.

# RegisterBoat:- 
This action method provides functionality to register any boat to be rent out. A user can provide boat name and hourly rate as parameter of action method. This method first check if tis boat name is already registered. If yes then will give a message that “boat <Name> is already registered.”  Otherwise method will try to register the boat into SQL Server “Boat Table (with columns BoatID<INT>, RegistrationID<NEWID>,  BoatName<NVARCHAR(50)>, HourlyRate<DECIMAL>, BookedBy<NVARCHAR(50)>, BookedDate<DATETIME>, IsBooked<BIT>). If data get saved successfully in the table then RegistrationID (NEWID) will get provided to client as boat number. If any exception occurred then user friendly message will get returned to client.

# BookBoat: 
This action method accept two parameter i.e. boat number and customer name. It will check that if boat already booked by checking “IsBooked” column value as TRUE and then return one message to the client that “Boat <Name> already booked.”. If value of column “IsBooked” is FALSE then method will convert column value to true and provide message that “boat <Name> is booked for you”. In case if we get some other exception with we get into catch block then we need to display a user friendly message.

# Note: 
We need to create one extra action method (let say UnBookBoat) so that when user returns the boat, we can mark “IsBooked” column FLASE to make further booking.
