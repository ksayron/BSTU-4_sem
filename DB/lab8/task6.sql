alter view [Pulpit_amount] with schemabinding
as select p.FACULTY [name],Count(*)[amount]
 from dbo.PULPIT p inner join dbo.FACULTY f on p.FACULTY = f.FACULTY
 Group by p.FACULTY
 select * from Pulpit_amount
 alter table PULPIT drop column FACULTY