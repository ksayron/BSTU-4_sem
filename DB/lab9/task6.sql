select  G.FACULTY, Case
when p.NOTE > 8 then 'good'
when p.NOTE between 6 and 8 then 'norm'
when p.NOTE < 6 then 'bad'
else '...'
end status,
count(*) [count]

from STUDENT s
join PROGRESS p on p.IDSTUDENT = s.IDSTUDENT
join GROUPS g on s.IDGROUP = g.IDGROUP
where g.FACULTY like 'хр'

group by G.FACULTY,
Case
when p.NOTE > 8 then 'good'
when p.NOTE between 6 and 8 then 'norm'
when p.NOTE < 6 then 'bad'
else '...'
end