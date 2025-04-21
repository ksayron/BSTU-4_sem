declare @i int = 1,
		@c char = 'k',
		@v varchar,
		@s smallint,
		@dt datetime,
		@t time,
		@ti tinyint,
		@n numeric(12,5);
select @s = 2;
set @ti = 3;
set @dt = GETDATE();
set @t = GETDATE();
set @n = 12.4;
set @v = 'v';
select @i i,@dt dt,@t t,@s s,@n n,@ti ti;
print @v;
print @c;