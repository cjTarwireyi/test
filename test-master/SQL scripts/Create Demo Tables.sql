/* Create Employer Table*/
drop database if exists Employer
create table Employer (
	Id int primary key,
	FullName varchar(50),
	EmployerAddress varchar(100)
);

go

/* Create CustomerAddress Table */
drop database if exists CustomerAddress
create table CustomerAddress (
	Id int not null primary key,
	PhysicalAddress varchar(100) not null,
	PhysicalAddressPostalCode int not null,
	PostalAddress varchar,
	PostalAddressPostalCode int
);

go

/* Create CustomerContactDetail */
drop database if exists CustomerContactDetail
create table CustomerContactDetail (
	Id int not null primary key, 
	HomeNo varchar(20),
	CellNo varchar(20) not null,
	WorkNo varchar(20),
	Email varchar(30) not null
);

go

/* Create Customer Table */
drop database if exists Customer
create table Customer (
	Id int not null primary key,
	FullName varchar(50) not null,
	IdentityNo varchar(13) not null,
	CustomerAddressId int not null foreign key references CustomerAddress(Id),
	CustomerContactDetailsId int not null foreign key references CustomerContactDetail(Id),
	EmployerId int not null foreign key references Employer(Id)
);

go