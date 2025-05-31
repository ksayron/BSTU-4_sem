	drop table PULPIT_COPY
	select * into PULPIT_COPY from PULPIT
	--A
	set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from PULPIT_COPY where FACULTY = 'ÈÒ'
	--------------t1--------------
	select count(*) from PULPIT_COPY where FACULTY = 'ÈÒ'
	--------------t2-----------------
	commit

	--- B --	
	begin transaction
	delete from PULPIT_COPY where PULPIT = 'ÈÒ'
	-------------------------- t1 ------------------
	rollback
	--------------------------t2---------------
	begin transaction 
    update PULPIT_COPY set PULPIT = 'Transact' where FACULTY = 'ÈÒ';
	commit