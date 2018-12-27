--drop table EmployerAddress
create table EmployerAddress (
	Id int primary key,
	EmployerId int foreign key references Employer(Id) not null,
	AddressTypeId int foreign key references AddressType(Id) not null,
	Line1 varchar(100),
	Line2 varchar(100),
	City varchar(50) not null,
	State varchar(50) not null,
	zip int not null
)