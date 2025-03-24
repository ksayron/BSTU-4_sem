select IDSTUDENT,NOTE
from PROGRESS
where NOTE >=all (select Note from PROGRESS)

select IDSTUDENT,NOTE
from PROGRESS
where NOTE <any (select avg(NOTE) from PROGRESS)