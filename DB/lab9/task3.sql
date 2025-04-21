
select * from AUDITORIUM
print 'число обработанных строк - ' + convert(varchar, @@ROWCOUNT)
print 'версия SQL Server - ' + convert(varchar, @@VERSION)
print 'системный идентификатор процессa - ' + convert(varchar, @@SPID)
print 'код последней ошибки - ' + convert(varchar, @@ERROR)
print 'имя сервера - ' + convert(varchar, @@SERVERNAME)
print 'уровень вложенности транзакции - ' + convert(varchar, @@TRANCOUNT)
print 'результат считывания строк результирующего набора - ' + convert(varchar, @@FETCH_STATUS)
print 'уровень вложенности текущей процедуры - ' + convert(varchar, @@NESTLEVEL)