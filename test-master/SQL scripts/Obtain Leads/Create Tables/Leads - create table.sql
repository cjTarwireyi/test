--drop table Leads
Create Table Lead (
	Id int primary key,
	Name varchar(100),
	Sent varchar(1),
	InsertedDate datetime,
	UpdatedDate datetime
);