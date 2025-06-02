alter function auditoim_count () returns int
as 
begin
declare @count int = 0
declare @aud NVarchar(10)
declare dsc_cur cursor 
for select AUDITORIUM from AUDITORIUM
open dsc_cur
fetch dsc_cur into @aud
while @@FETCH_STATUS = 0
	begin
	set @count = @count + SUBSTRING(@aud,0,Len(@aud)-1)
	fetch dsc_cur into @aud
	end
return @count
end
go

declare @f int = dbo.auditoim_count()
print @f