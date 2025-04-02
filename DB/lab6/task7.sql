select p1.SUBJECT,p1.NOTE,
	(select count(*) from PROGRESS p2
	where p1.SUBJECT = p2.SUBJECT and p1.NOTE = p2.NOTE
	)[col-vo]
from PROGRESS p1
group by p1.SUBJECT,p1.NOTE
having p1.NOTE >7 and p1.NOTE < 10