select name,round(avg(cast(Experience as float(4))),2)
from Drivers dr
where name in ('John', 'Joe','Jeremy')
group by dr.Name