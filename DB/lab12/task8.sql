drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT

begin tran
	insert PULPIT_COPY values ('ИТ', 'Программная инженерия', 'ИТ')
	begin tran
	update PULPIT_COPY set PULPIT_NAME='Transact'
	print @@trancount
	commit

	
	if @@TRANCOUNT > 0 rollback;
	print @@trancount
	select * from PULPIT_COPY where FACULTY = 'ИТ'