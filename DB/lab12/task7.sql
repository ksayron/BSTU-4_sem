	drop table PULPIT_COPY
	select * into PULPIT_COPY from PULPIT
	-- A ---
	set transaction isolation level SERIALIZABLE
	begin transaction 
	select count(*) from PULPIT_COPY where FACULTY = 'ИТ'
	--------------t1--------------
	commit
	--------------t2-----------------
	select count(*) from PULPIT_COPY where FACULTY = 'ИТ'

	--- B --	

	begin transaction 
	insert PULPIT_COPY values ('ИТ', 'Программная инженерия', 'ИТ')