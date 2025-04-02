select name,round(avg(cast(Experience as float(4))),2)
from Drivers dr
group by dr.Name