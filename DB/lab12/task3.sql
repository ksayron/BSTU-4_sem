drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT
select * from PULPIT_COPY
alter table PULPIT_COPY
add constraint PK_PULPIT_COPY primary key (PULPIT);

declare @point varchar(32)

begin try
	begin tran
	delete PULPIT_COPY where FACULTY = 'ЛХФ'
	set @point = 'p1'; save tran @point
	insert PULPIT_COPY values ('ИТ', 'Программная инженерия', 'ИТ')
	set @point = 'p2'; save tran @point
	insert PULPIT_COPY values ('ИТ', 'Программная инженерия', 'ИТ')
	set @point = 'p3'; save tran @point
	commit tran
	print 'ok'
end try
	
begin catch
print 'error:' + cast(error_number() as varchar(10)) + ' ' + cast(error_message() as varchar(100))

if @@TRANCOUNT > 0
	begin
		print 'control point: ' + @point 
		rollback tran @point;
		commit tran
	end;
end catch

select * from PULPIT_COPY