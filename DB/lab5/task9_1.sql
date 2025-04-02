
select Drivers.DriverID
from ActiveRoutes inner join Drivers
on ActiveRoutes.DriverID = Drivers.DriverID
where Drivers.DriverID in 
(select ActiveRoutes.DriverID from ActiveRoutes where (Surname like '%Doe%'))