create view Auditorii(id,name)
 as select a.AUDITORIUM,a.AUDITORIUM_NAME from AUDITORIUM a 
 where a.AUDITORIUM_TYPE like '��%';
 go
 Select * from Auditorii
