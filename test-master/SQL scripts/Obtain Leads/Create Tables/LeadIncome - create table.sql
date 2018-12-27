--drop table LeadIncome
create table LeadIncome(
	Id int primary key,
	LeadId int foreign key references Lead(Id),
	IncomeTypeId int foreign key references IncomeType(Id),
	Amount numeric
)