DECLARE @surname CHAR(20), @output NVARCHAR(200) = N' '
DECLARE driver_cur CURSOR 
FOR SELECT Surname FROM Drivers

OPEN driver_cur
FETCH driver_cur INTO @surname
PRINT 'Фамилии водителей:'
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @output = RTRIM(@surname) + ', ' + @output
    FETCH driver_cur INTO @surname
END
PRINT @output
CLOSE driver_cur
DEALLOCATE driver_cur
GO
