select PULPIT_NAME
from pulpit inner join FACULTY
on PULPIT.FACULTY = FACULTY.FACULTY
where FACULTY.FACULTY in 
(select PROFESSION.FACULTY from PROFESSION where (PROFESSION.PROFESSION_NAME like '%технологи%'))