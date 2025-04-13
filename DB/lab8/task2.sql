Create View [Pulpit_amount]
 as select p.FACULTY [name],Count(*)[amount]
 from PULPIT p inner join FACULTY f on p.FACULTY = f.FACULTY
 Group by p.FACULTY
 select * from [Pulpit_amount]