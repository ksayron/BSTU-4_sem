drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT
select * from PULPIT_COPY
-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
    select count(*) from PULPIT_COPY where FACULTY = '��';
	--------------------t1----------------
	select count(*) from PULPIT_COPY where FACULTY = '��';
	--------------------t2-------------------
	commit
	select * from PULPIT_COPY

	drop table PULPIT_COPY
select * into PULPIT_COPY from PULPIT
	-- B ---
	begin transaction 
    delete from PULPIT_COPY where FACULTY = '��'; 
	select * from PULPIT_COPY

