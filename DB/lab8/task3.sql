
--drop view Auditorii
create view Auditorii(id,type)
 as select a.AUDITORIUM,a.AUDITORIUM_TYPE from AUDITORIUM a 
 where a.AUDITORIUM_TYPE like 'À %';
 go
 Select * from Auditorii
  Select * from AUDITORIUM
 insert Auditorii values('1020-1','À¡-X      ')

