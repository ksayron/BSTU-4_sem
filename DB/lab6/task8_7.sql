select d1.Name,d1.Experience,
	(select count(*) from Drivers d2
	where d1.Name = d2.Name and d1.Experience = d2.Experience
	)[col-vo]
from Drivers d1
group by d1.Name,d1.Experience
having d1.Experience >2 and d1.Experience < 15