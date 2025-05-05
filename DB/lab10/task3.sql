create table #temp3
(
	ID int identity(1,1),
	randnum real,
);

set nocount on
declare @i int = 0
while @i < 10000
begin
	insert #temp3
	values (floor(3000* rand()))
	set @i = @i + 1
end

checkpoint; 
DBCC DROPCLEANBUFFERS; 

select * from #temp3
where randnum > 1000
order by randnum

create index #temp_nonclu on #temp3(randnum) include (ID)
drop index #temp_nonclu on #temp3