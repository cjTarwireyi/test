--drop table LeadDeduction
create table LeadDeduction (
	Id int primary key,
	LeadId int foreign key references Lead(Id),
	DeductionTypeId int foreign key references DeductionType(Id),
	Amount numeric
)