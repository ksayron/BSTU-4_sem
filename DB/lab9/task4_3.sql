declare @currentDate datetime = getdate()

select STUDENT.NAME, STUDENT.BDAY, 
datediff(yy, STUDENT.BDAY, @currentDate) age
from STUDENT
where MONTH(STUDENT.BDAY) = MONTH(dateadd(m, 1, @currentDate))