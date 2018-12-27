--drop table LeadContactDetail
create table LeadContactDetail(
	Id int primary key,
	LeadsId int foreign key references Lead(Id) not null,
	HomeNo varchar(20),
	CellNo varchar(20) not null,
	Email varchar(50) not null
);

