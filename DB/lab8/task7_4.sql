create view pro_drivers2(id,lastname,name,expirience)
as select DriverID,LastName,Name,Experience from Drivers where Experience>5 with check option;
select * from pro_drivers2