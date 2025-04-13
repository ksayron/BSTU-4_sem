create view Auditorii2(id,name)
 as select a.AUDITORIUM,a.AUDITORIUM_NAME from AUDITORIUM a 
 where a.AUDITORIUM_TYPE like 'À %' with check option;
 go
 Select * from Auditorii
