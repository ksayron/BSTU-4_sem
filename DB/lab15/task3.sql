create trigger TR_TEACHER_UPD on TEACHER after UPDATE
as 
    declare @a1 char(10), @a2 nvarchar(100), @a3 char(1), @a4 char(20), @in nvarchar(300);
    declare @old_data nvarchar(300), @new_data nvarchar(300);
    
    print 'Операция обновления';

    -- Получаем новые значения (из inserted)
    set @a1 = (select [Teacher] from inserted);
    set @a2 = (select [Teacher_Name] from inserted);
    set @a3 = (select [Gender] from inserted);
    set @a4 = (select [Pulpit] from inserted);
    set @new_data = @a1 + ',' + @a2 + ', ' + @a3 + ', ' + @a4;

    -- Получаем старые значения (из deleted)
    set @a1 = (select [Teacher] from deleted);
    set @a2 = (select [Teacher_Name] from deleted);
    set @a3 = (select [Gender] from deleted);
    set @a4 = (select [Pulpit] from deleted);
    set @old_data = @a1 + ',' + @a2 + ', ' + @a3 + ', ' + @a4;

    -- Формируем итоговую строку: старые значения -> новые значения
    set @in = 'Было: ' + @old_data + ' -> Стало: ' + @new_data;
    
    insert into TR_AUDIT (stmt, trname, cc)
    values ('UPD', 'TR_TEACHER_UPD', @in);
    return;

update TEACHER set TEACHER = 'КЧРК' where TEACHER = 'КЧРК'
select * from TR_AUDIT

select * from TEACHER
delete from TR_AUDIT
drop trigger TR_TEACHER_UPD