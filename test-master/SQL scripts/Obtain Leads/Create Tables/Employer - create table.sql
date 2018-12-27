--drop table Employer
Create Table Employer(
	Id int primary key,
	LeadsId int foreign key references Lead(Id),
	EmployerName varchar(30),
)