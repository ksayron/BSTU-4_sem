create table table1(
ID int primary key not null,
Value nvarchar(10)
)
INSERT INTO table1(ID,Value)
Values(1,'one'),
      (2,'two'),
	  (3,'three')

create table table2(
ID int primary key not null,
Value nvarchar(20)
)
INSERT INTO table2(ID,Value)
Values(2,'John Doe'),
      (4,'Swiss'),
	  (6,'Frank')

Select	table1.ID,table2.Value
from table1 full outer join table2
on table1.ID = table2.ID