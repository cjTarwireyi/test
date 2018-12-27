--drop table MonthlyCommitments
create table MonthlyCommitments(
	Id int primary key,
	LeadId int foreign key references Lead(Id) not null,
	Commitment varchar(50) not null,
	MonthlyExpense numeric not null
)