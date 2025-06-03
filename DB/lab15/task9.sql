CREATE TRIGGER UniverDDLTR ON DATABASE 
FOR DDL_DATABASE_LEVEL_EVENTS 
AS   
BEGIN
    DECLARE @eventType VARCHAR(50) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'VARCHAR(50)');
    DECLARE @objectName VARCHAR(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'VARCHAR(50)');
    DECLARE @objectType VARCHAR(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'VARCHAR(50)'); 
    
    IF @objectName = 'TEACHER' 
    BEGIN
        PRINT 'Тип события: ' + @eventType;
        PRINT 'Имя объекта: ' + @objectName;
        PRINT 'Тип объекта: ' + @objectType;
        RAISERROR(N'Изменения в таблице TEACHER запрещены!', 16, 1);  
        ROLLBACK TRANSACTION;    
    END;
END;
GO


ALTER TABLE TEACHER DROP COLUMN TEACHER_NAME;
GO

drop trigger Univer