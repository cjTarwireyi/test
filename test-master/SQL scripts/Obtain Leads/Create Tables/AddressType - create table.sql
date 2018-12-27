--drop table AddressType
create table AddressType (
	Id int primary key,
	Type varchar(20) not null,
	Description varchar(100)
)