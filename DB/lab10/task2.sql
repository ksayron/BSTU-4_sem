create table #temp2
(
	ID int identity(1,1),
	randnum real,
);

set nocount on
declare @i int = 0
while @i < 10000
begin
	insert #temp2
	values (floor(3000* rand()))
	set @i = @i + 1
end

checkpoint; 
DBCC DROPCLEANBUFFERS; 

select * from #temp2
where randnum = 1000 and ID < 3000
order by randnum

create index #temp_nonclu on #temp2(ID, randnum)

drop index #temp_nonclu on #temp2
drop table #temp2