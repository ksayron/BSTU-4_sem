create view [active_drivers]
as select dr.DriverID[id],Name[name],LastName[lastname],Experience[exp] from Drivers dr inner join ActiveRoutes ar on dr.DriverID = ar.DriverID;
select * from active_drivers