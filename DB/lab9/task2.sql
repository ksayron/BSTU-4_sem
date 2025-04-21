declare @total int = (select sum(AUDITORIUM_CAPACITY) from AUDITORIUM),
@count int,
@avg real,
@less real

if @total > 200
begin
	select @count = (select count(*) from AUDITORIUM),
	@avg = (select avg(AUDITORIUM_CAPACITY) from AUDITORIUM)

	set @less = (select count(*) from AUDITORIUM
		where AUDITORIUM_CAPACITY < @avg)

	select @count 'count',
	@avg 'avg',
	@less 'less',
	(@less / @count) * 100 'percentage'
end

else 
	print  convert(varchar, @count)