select top 1
(select avg(PayRate) from Routes where FirstCityID like '1'),
(select avg(PayRate) from Routes where SecondCityID like '3')
from Routes