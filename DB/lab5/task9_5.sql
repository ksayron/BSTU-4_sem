select Surname,Name
from Drivers d 
where not exists (select *
from ActiveRoutes ar full outer join Drivers dr on ar.DriverID = dr.DriverID)