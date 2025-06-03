create trigger Univer_Tran on TEACHER after INSERT, DELETE, UPDATE
as 
    declare @c int = (select COUNT(TEACHER) from TEACHER);
    if (@c > 14)
    begin
        raiserror('Ошибка: количество преподавателей не должно превышать 14', 10, 1);
        rollback transaction;
    end;
    return;
go

-- Тестовая вставка преподавателя
insert into TEACHER
values('ИВНВ', 'Иванов Иван Иванович', 'м', 'ИСиТ');

-- Просмотр таблицы преподавателей
select * from TEACHER;

-- Удаление триггера
drop trigger Univer_Tran;