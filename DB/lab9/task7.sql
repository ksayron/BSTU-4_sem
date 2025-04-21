create table #temp 
(randint int,
randint2 int,
randint3 int
);

declare @i int = 0
while @i < 10
	begin
	insert #temp(randint, randint2, randint3)
	values (
	10 * RAND(),
	100 * RAND(),
	1000 * RAND()
	)
	set @i = @i + 1
	end


select * from #temp

drop table #temp