select DaysActive,Experience, count(*)
from ActiveRoutes ar inner join Drivers dr on ar.DriverID=dr.DriverID
Where Experience between 1 and 5
group by DaysActive,Experience
except
select DaysActive,Experience, count(*)
from ActiveRoutes ar inner join Drivers dr on ar.DriverID=dr.DriverID
Where Experience between 4 and 8
group by DaysActive,Experience