DROP PROCEDURE IF EXISTS PRoutes;
GO

CREATE PROCEDURE PRoutes
AS
BEGIN
    DECLARE @count INT = (SELECT COUNT(*) FROM Routes);

    SELECT 
        RouteID AS [Код],
        PayRate AS [Зарплата],
        Lenght AS [Расстояние]
    FROM Routes;

    RETURN @count;
END;
GO

DECLARE @output INT = 0;
EXEC @output = PRoutes;
PRINT N'Количество маршрутов = ' + CAST(@output AS VARCHAR(5));
--2
GO
ALTER PROCEDURE PRoutes
    @id INT, 
    @count INT OUTPUT
AS
BEGIN
    DECLARE @total INT = (SELECT COUNT(*) FROM Routes);

    SELECT 
        RouteID AS [Код],
        PayRate AS [Зарплата],
        Lenght AS [Расстояние]
    FROM Routes
    WHERE RouteID = @id;

    SET @count = @@ROWCOUNT;
    RETURN @total;
END;
GO


DECLARE @total INT = 0, @selected INT = 0;
EXEC @total = PRoutes @id = 1, @count = @selected OUTPUT;

PRINT N'Всего маршрутов: ' + CAST(@total AS VARCHAR(5));
PRINT N'Найдено маршрутов с ID=1: ' + CAST(@selected AS VARCHAR(5));
--3
go
ALTER PROCEDURE PRoutes @id INT
AS
BEGIN
    SELECT RouteID, PayRate, Lenght
    FROM Routes
    WHERE RouteID = @id;
END;
GO

CREATE TABLE #RouteBuffer (
    RouteID INT PRIMARY KEY,
    RouteName NVARCHAR(100),
    Distance INT
);

INSERT INTO #RouteBuffer EXEC PRoutes @id = 1;
INSERT INTO #RouteBuffer EXEC PRoutes @id = 2;

SELECT * FROM #RouteBuffer;
--4
go
CREATE PROCEDURE PDriver_Insert
    @Name NVARCHAR(100),
    @LastName NVARCHAR(20),
    @ExperienceYears INT = 0
AS 
DECLARE @rc INT = 1;

BEGIN TRY
    INSERT INTO Drivers (Name, LastName, Experience)
    VALUES (@Name, @LastName, @ExperienceYears);

    RETURN @rc;
END TRY
BEGIN CATCH
    PRINT N'Ошибка №: ' + CAST(ERROR_NUMBER() AS VARCHAR);
    PRINT N'Сообщение: ' + ERROR_MESSAGE();
    PRINT N'Процедура: ' + ISNULL(ERROR_PROCEDURE(), N'не определена');
    RETURN -1;
END CATCH;
GO

-- Вызов:
DECLARE @rc INT;
EXEC @rc = PDriver_Insert 
    @Name = 'Misha', 
    @LastName = 'Bublikov', 
    @ExperienceYears = 5;

PRINT N'Результат выполнения: ' + CAST(@rc AS VARCHAR);
--5
go
CREATE PROCEDURE PDriverRoutesReport @DriverID INT
AS
BEGIN TRY
    DECLARE @PayRate NVARCHAR(100);
    DECLARE @msg NVARCHAR(1000) = N'';
    DECLARE @count INT = 0;

    IF NOT EXISTS (
        SELECT 1 FROM ActiveRoutes WHERE DriverID = @DriverID
    )
        RAISERROR(N'Нет активных маршрутов для водителя', 11, 1);

    DECLARE route_cur CURSOR LOCAL STATIC FOR
        SELECT R.PayRate
        FROM ActiveRoutes AR
        JOIN Routes R ON AR.RouteID = R.RouteID
        WHERE AR.DriverID = @DriverID;

    OPEN route_cur;
    FETCH route_cur INTO @RouteName;

    PRINT N'Зарплата водителя:';

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @msg += @PayRate + N', ';
        SET @count += 1;
        FETCH route_cur INTO @RouteName;
    END

    CLOSE route_cur;
    DEALLOCATE route_cur;

    PRINT LEFT(@msg, LEN(@msg) - 2); 
    RETURN @count;
END TRY
BEGIN CATCH
    PRINT N'Ошибка: ' + ERROR_MESSAGE();
    RETURN -1;
END CATCH;
GO


DECLARE @result INT;
EXEC @result = PDriverRoutesReport @DriverID = 1;
PRINT N'Количество маршрутов: ' + CAST(@result AS VARCHAR);
go
--6
CREATE PROCEDURE PAddFullRoute
    @RouteName NVARCHAR(100),
    @Distance INT,
	@PayRate INT,
    @DepartureCityID INT,
    @ArrivalCityID INT,
    @DriverID INT,
    @DepartureDate DATE,
    @Status NVARCHAR(50)
AS
BEGIN TRY
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRAN;

    DECLARE @NewRouteID INT;

    INSERT INTO Routes (RouteID, Lenght,PayRate, FirstCityID, SecondCityID)
    VALUES (@RouteName, @Distance, @PayRate,@DepartureCityID, @ArrivalCityID);

    SET @NewRouteID = SCOPE_IDENTITY();

    INSERT INTO ActiveRoutes (RouteID, DriverID, DepartureDate)
    VALUES (@NewRouteID, @DriverID, @DepartureDate);

    COMMIT TRAN;
    RETURN 1;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRAN;

    PRINT N'Ошибка: ' + ERROR_MESSAGE();
    RETURN -1;
END CATCH;
GO

-- Вызов:
DECLARE @rc INT;
EXEC @rc = PAddFullRoute
    @RouteName = N'Минск — Гомель',
    @Distance = 300,
	@PayRate = 120,
    @DepartureCityID = 1,
    @ArrivalCityID = 2,
    @DriverID = 1,
    @DepartureDate = '2025-06-01',
    @Status = N'Назначен';

PRINT N'Результат: ' + CAST(@rc AS VARCHAR);


