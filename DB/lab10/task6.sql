create table #temp5
(
	ID int identity(1,1),
	randnum real,
);

set nocount on
declare @i int = 0
while @i < 10000
begin
	insert #temp5
	values (floor(3000* rand()))
	set @i = @i + 1
end

checkpoint; 
DBCC DROPCLEANBUFFERS; 

select randnum from #temp5
where randnum >= 1500 and randnum <= 3000
order by randnum

create index #temp5_indx on #temp5(randnum) with (fillfactor=65)

INSERT top(50)percent INTO #temp5(randnum)
SELECT randnum from #temp5

SELECT 
    i.name AS [name],
    ips.avg_fragmentation_in_percent AS [fragmentation (%)]
FROM sys.dm_db_index_physical_stats (
    DB_ID('tempdb'), 
    OBJECT_ID('tempdb..#temp5'), 
    NULL, 
    NULL, 
    NULL
) AS ips
JOIN tempdb.sys.indexes AS i 
    ON ips.object_id = i.object_id 
    AND ips.index_id = i.index_id
WHERE i.name IS NOT NULL;

drop index #temp5_indx on #temp5
drop table #temp5