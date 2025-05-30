--7-6-1
SELECT * INTO Drivers_copy FROM Drivers

DECLARE @name NVARCHAR(20), @exp INT
DECLARE d_cursor CURSOR LOCAL
FOR SELECT Name, Experience FROM Drivers_copy WHERE Experience < 3 FOR UPDATE

OPEN d_cursor
FETCH d_cursor INTO @name, @exp
WHILE @@FETCH_STATUS = 0
BEGIN
    DELETE FROM Drivers_copy WHERE CURRENT OF d_cursor
    FETCH d_cursor INTO @name, @exp
END
CLOSE d_cursor
DEALLOCATE d_cursor
GO
Drop table Drivers_copy
--7-6-2
SELECT * INTO Drivers_copy FROM Drivers
SELECT * FROM Drivers_copy
DECLARE @name NVARCHAR(20), @exp INT
DECLARE d_cursor CURSOR LOCAL
FOR SELECT Name, Experience FROM Drivers_copy WHERE Experience < 5 FOR UPDATE

OPEN d_cursor
FETCH d_cursor INTO @name, @exp
WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE Drivers_copy SET Experience = Experience + 1 WHERE CURRENT OF d_cursor
    FETCH d_cursor INTO @name, @exp
END
CLOSE d_cursor
DEALLOCATE d_cursor
GO
SELECT * FROM Drivers_copy
Drop table Drivers_copy