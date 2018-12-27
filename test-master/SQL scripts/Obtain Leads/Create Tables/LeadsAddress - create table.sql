--drop table LeadAddress
create table LeadAddress (
	Id int primary key,
	LeadsId int foreign key references Lead(Id) not null,
	AddressTypeId int foreign key references AddressType(Id) not null,
	Line1 varchar(100),
	Line2 varchar(100), 
	City varchar(50),
	State varchar(50),
	zip int
)