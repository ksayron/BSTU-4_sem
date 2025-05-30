SELECT * INTO Drivers_copy FROM Drivers
SELECT * FROM Drivers_copy

DECLARE @surname CHAR(20)
DECLARE driver_cur CURSOR LOCAL
FOR SELECT Surname FROM Drivers_copy FOR UPDATE

OPEN driver_cur

SELECT * FROM Drivers_copy

-- Удалить текущего водителя
FETCH FROM driver_cur INTO @surname
DELETE FROM Drivers_copy WHERE CURRENT OF driver_cur

-- Обновить текущего водителя
FETCH FROM driver_cur INTO @surname
UPDATE Drivers_copy SET Surname = 'Testov' WHERE CURRENT OF driver_cur

SELECT * FROM Drivers_copy

CLOSE driver_cur
DEALLOCATE driver_cur
GO

Drop table Drivers_copy