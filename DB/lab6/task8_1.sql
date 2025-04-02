select dr.Name, max(Experience),min(Experience),AVG(Experience),SUM(Experience),COUNT(*)
from ActiveRoutes ar inner join Drivers dr on ar.DriverID = dr.DriverID
group by dr.Name