create table #temp4
(
	ID int identity(1,1),
	randnum real,
);

set nocount on
declare @i int = 0
while @i < 10000
begin
	insert #temp4
	values (floor(3000* rand()))
	set @i = @i + 1
end

checkpoint; 
DBCC DROPCLEANBUFFERS; 

select randnum from #temp4
where randnum >= 1500 and randnum <= 3000
order by randnum

create index #temp_nonclu on #temp4(randnum) where (randnum >= 1500 and randnum <= 3000)
drop index #temp_nonclu on #temp4