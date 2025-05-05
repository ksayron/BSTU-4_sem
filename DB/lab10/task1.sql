exec SP_HELPINDEX 'AUDITORIUM' 
exec SP_HELPINDEX 'AUDITORIUM_TYPE'
exec SP_HELPINDEX 'FACULTY'
exec SP_HELPINDEX 'GROUPS'
exec SP_HELPINDEX 'PROFESSION'
exec SP_HELPINDEX 'PROGRESS'
exec SP_HELPINDEX 'PULPIT'
exec SP_HELPINDEX 'STUDENT'
exec SP_HELPINDEX 'SUBJECT'
exec SP_HELPINDEX 'TEACHER'

create table #temp
(
	ID int identity(1,1),
	randnum real
);

set nocount on
declare @i int = 0
while @i < 10000
begin
	insert #temp
	values (floor(3000* rand()))
	set @i = @i + 1
end

checkpoint; 
DBCC DROPCLEANBUFFERS; 
select * from #temp
where randnum between 200 and 1000
order by randnum

create clustered index #temp_cl on #temp(randnum asc)
drop index #temp_cl on #temp
drop table #temp