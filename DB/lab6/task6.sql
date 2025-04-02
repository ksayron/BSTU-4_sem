select f.FACULTY_NAME,g.PROFESSION,p.SUBJECT,round(avg(cast(p.NOTE as float(4))),2)[avg]
from STUDENT s left outer join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT inner join GROUPS g on s.IDGROUP = g.IDGROUP inner join FACULTY f on g.FACULTY= f.FACULTY
where f.FACULTY = 'рнб'
group by f.FACULTY_NAME,g.PROFESSION,p.SUBJECT