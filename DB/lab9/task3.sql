
select * from AUDITORIUM
print '����� ������������ ����� - ' + convert(varchar, @@ROWCOUNT)
print '������ SQL Server - ' + convert(varchar, @@VERSION)
print '��������� ������������� �������a - ' + convert(varchar, @@SPID)
print '��� ��������� ������ - ' + convert(varchar, @@ERROR)
print '��� ������� - ' + convert(varchar, @@SERVERNAME)
print '������� ����������� ���������� - ' + convert(varchar, @@TRANCOUNT)
print '��������� ���������� ����� ��������������� ������ - ' + convert(varchar, @@FETCH_STATUS)
print '������� ����������� ������� ��������� - ' + convert(varchar, @@NESTLEVEL)