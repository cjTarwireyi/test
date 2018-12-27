--drop table EmployerContactDetail 
create table EmployerContactDetail ( 
	Id int primary key,
	EmployerId int foreign key references Employer(Id),
	WorkNo varchar(20),
	Email varchar(20)
)