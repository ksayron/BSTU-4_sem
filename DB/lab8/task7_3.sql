create view pro_drivers(id,lastname,name,expirience)
as select DriverID,LastName,Name,Experience from Drivers where Experience>5;
select * from pro_drivers