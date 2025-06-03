-- Создание INSTEAD OF триггера для таблицы TEACHER
create trigger Univer_INSTEADOF on TEACHER INSTEAD OF DELETE
as 
    -- Вывод сообщения об ошибке при попытке удаления
    raiserror('Удаление преподавателей запрещено!', 10, 1);
    return;
go

-- Попытка удаления преподавателя (будет перехвачена триггером)
delete from TEACHER where TEACHER = 'ИВНВ';

-- Просмотр данных в таблице TEACHER
select * from TEACHER;

-- Удаление триггера
drop trigger Univer_INSTEADOF;