	drop table PULPIT_COPY
	select * into PULPIT_COPY from PULPIT
	-- A ---
	set transaction isolation level REPEATABLE READ 
	begin transaction 
	select count(*) from PULPIT_COPY where FACULTY = '��'
	--------------t1--------------
	commit
	--------------t2-----------------
	select count(*) from PULPIT_COPY where  FACULTY = '��'
	-------B----------
--- B --	

	-------------t1----------------
	begin transaction 
	insert PULPIT_COPY values ('��', '����������� ���������', '��')
	commit
	------------------------t2---------------------
	begin transaction 
    update PULPIT_COPY set PULPIT = 'Transact' where FACULTY = '��';
	commit