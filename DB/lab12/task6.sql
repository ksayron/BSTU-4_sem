	drop table PULPIT_COPY
	select * into PULPIT_COPY from PULPIT
	-- A ---
	set transaction isolation level REPEATABLE READ 
	begin transaction 
	select count(*) from PULPIT_COPY where FACULTY = 'ИТ'
	--------------t1--------------
	commit
	--------------t2-----------------
	select count(*) from PULPIT_COPY where  FACULTY = 'ИТ'
	-------B----------
--- B --	

	-------------t1----------------
	begin transaction 
	insert PULPIT_COPY values ('ИТ', 'Программная инженерия', 'ИТ')
	commit
	------------------------t2---------------------
	begin transaction 
    update PULPIT_COPY set PULPIT = 'Transact' where FACULTY = 'ИТ';
	commit