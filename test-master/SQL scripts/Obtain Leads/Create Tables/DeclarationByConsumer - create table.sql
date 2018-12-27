--drop table DeclarationByConsumer
create table DeclarationByConsumer(
	Id int primary key,
	LeadId int foreign key references Lead(Id) not null,
	SignedAt varchar(100) not null,
	Date datetime not null,
	Signed varchar(1) not null
)