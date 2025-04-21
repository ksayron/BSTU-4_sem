create table #temp1 
(randint int,
randint2 int,
randint3 int
);
begin try
	alter table #temp1
	drop column test_col
end try
begin catch
print ERROR_NUMBER()
print ERROR_MESSAGE() 
print ERROR_LINE ()
print ERROR_PROCEDURE()
print ERROR_SEVERITY()
print ERROR_STATE ()
end catch
drop table #temp1;