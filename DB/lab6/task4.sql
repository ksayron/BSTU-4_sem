select f.FACULTY_NAME,g.PROFESSION,g.YEAR_FIRST,round(avg(cast(p.NOTE as float(4))),2)
from STUDENT s inner join PROGRESS p on s.IDSTUDENT = p.IDSTUDENT inner join GROUPS g on s.IDGROUP = g.IDGROUP inner join FACULTY f on g.FACULTY= f.FACULTY
group by f.FACULTY_NAME,g.PROFESSION,g.YEAR_FIRST