drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT

--TASK4
-- B ---
	begin transaction 
    delete from PULPIT_COPY where PULPIT = '“À'; 

--TASK5
--- B --	
	begin transaction
	delete from PULPIT_COPY where PULPIT = '“À'
	-------------------------- t1 ------------------
	rollback
	--------------------------t2---------------
	begin transaction 
    update PULPIT_COPY set PULPIT = 'Transact' where PULPIT = '“À';
	commit


--TASK6
--- B --	
	------------------------t2---------------------
	begin transaction 
   update PULPIT_COPY set PULPIT = 'Transact' where PULPIT = '“À';
	commit
	-------------t1----------------
	begin transaction 
    insert PULPIT_COPY values ('“À', '«Ì‡ÌËÂ ÎÂÒ‡', 'À’‘')
	commit
	--------------t1-------------

--TASK7
--- B --	
	begin transaction 
	insert PULPIT_COPY values ('“À', '«Ì‡ÌËÂ ÎÂÒ‡', 'À’‘')
	commit
	-------------t1----------------