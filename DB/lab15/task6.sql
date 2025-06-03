create trigger TR_TEACHER_DEL1 on TEACHER after DELETE  
as
    declare @in nvarchar(300);
    set @in = 'Триггер TR_TEACHER_DEL1'
    insert into TR_AUDIT (stmt, trname, cc)
    values ('DEL', 'TR_TEACHER_DEL', @in);
    print 'TR_TEACHER_DEL1';
    return;  
go 

create trigger TR_TEACHER_DEL2 on TEACHER after DELETE  
as
    declare @in nvarchar(300);
    set @in = 'Триггер TR_TEACHER_DEL2'
    insert into TR_AUDIT (stmt, trname, cc)
    values ('DEL', 'TR_TEACHER_DEL', @in);
    print 'TR_TEACHER_DEL2';
    return;  
go 

create trigger TR_TEACHER_DEL3 on TEACHER after DELETE  
as
    declare @in nvarchar(300);
    set @in = 'Триггер TR_TEACHER_DEL3'
    insert into TR_AUDIT (stmt, trname, cc)
    values ('DEL', 'TR_TEACHER_DEL', @in);
    print 'TR_TEACHER_DEL3';
    return;  
go 

-- Тестовая вставка и удаление
insert into TEACHER
values('ИВНВ', 'Иванов Иван Иванович', 'м', 'ИСиТ')

delete from TEACHER where TEACHER = 'ИВНВ'

-- Просмотр триггеров
select t.name, e.type_desc 
from sys.triggers t join sys.trigger_events e  
on t.object_id = e.object_id  
where OBJECT_NAME(t.parent_id) = 'TE