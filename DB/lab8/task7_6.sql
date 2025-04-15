alter view [active_drivers] with schemabinding
as select dr.DriverID[id],Name[name],LastName[lastname],Experience[exp] from dbo.Drivers dr inner join dbo.ActiveRoutes ar on dr.DriverID = ar.DriverID;
select * from [active_drivers]