select f.FACULTY_NAME,g.PROFESSION,p.SUBJECT,round(avg(cast(p.NOTE as float(4))),2)[avg]
from STUDENT s left outer join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT inner join GROUPS g on s.IDGROUP = g.IDGROUP inner join FACULTY f on g.FACULTY= f.FACULTY
where f.FACULTY = '“Œ¬'
group by f.FACULTY_NAME,g.PROFESSION,p.SUBJECT
intersect
select f.FACULTY_NAME,g.PROFESSION,p.SUBJECT,round(avg(cast(p.NOTE as float(4))),2)[avg]
from STUDENT s left outer join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT inner join GROUPS g on s.IDGROUP = g.IDGROUP inner join FACULTY f on g.FACULTY= f.FACULTY
where f.FACULTY = '’“Ë“'
group by f.FACULTY_NAME,g.PROFESSION,p.SUBJECT;  