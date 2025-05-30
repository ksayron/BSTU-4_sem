DECLARE @surname CHAR(20)
DECLARE driver_cur CURSOR LOCAL SCROLL
FOR SELECT Surname FROM Drivers

OPEN driver_cur

FETCH FIRST FROM driver_cur INTO @surname
PRINT 'Первая строка: ' + @surname

FETCH LAST FROM driver_cur INTO @surname
PRINT 'Последняя строка: ' + @surname

FETCH ABSOLUTE 3 FROM driver_cur INTO @surname
PRINT 'Absolute 3: ' + @surname

FETCH RELATIVE 2 FROM driver_cur INTO @surname
PRINT 'Relative +2: ' + @surname

FETCH NEXT FROM driver_cur INTO @surname
PRINT 'Next: ' + @surname

FETCH PRIOR FROM driver_cur INTO @surname
PRINT 'Prior: ' + @surname

CLOSE driver_cur
DEALLOCATE driver_cur
GO
