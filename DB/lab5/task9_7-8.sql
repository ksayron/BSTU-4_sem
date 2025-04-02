select FirstCityID,PayRate
from Routes
where PayRate >=all (select PayRate from Routes)
select FirstCityID,PayRate
from Routes
where PayRate <=any (select avg(PayRate) from Routes)