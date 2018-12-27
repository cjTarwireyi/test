--drop table DebitObligation
create table DebitObligation(
	Id int primary key,
	LeadId int foreign key references Lead(Id) not null,
	DebtCommitment varchar(50) not null,
	NameOfCreditor varchar(50) not null,
	TotalAmountOutstanding numeric,
	MonthlyCommitment varchar(50)
)