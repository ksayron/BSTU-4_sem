SELECT * INTO Drivers_copy FROM Drivers 

DECLARE @surname CHAR(20), @output NVARCHAR(200) = N' '
DECLARE driver_cur CURSOR LOCAL STATIC
FOR SELECT Surname FROM Drivers_copy

OPEN driver_cur
PRINT 'Количество строк: ' + CAST(@@CURSOR_ROWS AS VARCHAR(5))

SELECT * FROM Drivers_copy


DELETE FROM Drivers_copy WHERE Surname LIKE N'%o%'

SELECT * FROM Drivers_copy

FETCH driver_cur INTO @surname
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @output = RTRIM(@surname) + ', ' + @output
    FETCH driver_cur INTO @surname
END
PRINT @output
CLOSE driver_cur
GO

Drop table Drivers_copy
