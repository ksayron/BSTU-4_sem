DROP TABLE  Routes_Copy;
SELECT * INTO Routes_Copy FROM Routes;

ALTER TABLE Routes_Copy
ADD CONSTRAINT PK_Routes_Copy PRIMARY KEY (Id);

BEGIN TRY
    BEGIN TRAN;
    
    DELETE FROM Routes_Copy WHERE Lenght > 1000;

    -- ������ ������� � �������
    INSERT INTO Routes_Copy VALUES (16, 1, 2, 950, 670);

    -- ������ ������� � ������ (�������� PK)
    INSERT INTO Routes_Copy VALUES (16, 1, 2, 950, 670);

    COMMIT TRAN;
    PRINT 'ok';
END TRY
BEGIN CATCH
    PRINT '������: �' + CAST(ERROR_NUMBER() AS VARCHAR(5)) + ' ' + ERROR_MESSAGE();

    IF @@TRANCOUNT > 0 ROLLBACK TRAN;
END CATCH

SELECT * FROM Routes_Copy;

DROP TABLE Routes_Copy;
SELECT * INTO Routes_Copy FROM Routes;

ALTER TABLE Routes_Copy
ADD CONSTRAINT PK_Routes_Copy PRIMARY KEY (Id);

BEGIN TRY
    BEGIN TRAN;
    
    DELETE FROM Routes_Copy WHERE Lenght > 1000;

    -- ������ ������� � �������
    INSERT INTO Routes_Copy VALUES (999, 1, 2, 950, '12:00');

    -- ������ ������� � ������ (�������� PK)
    INSERT INTO Routes_Copy VALUES (999, 1, 2, 950, '12:00');

    COMMIT TRAN;
    PRINT 'ok';
END TRY
BEGIN CATCH
    PRINT '������: �' + CAST(ERROR_NUMBER() AS VARCHAR(5)) + ' ' + ERROR_MESSAGE();

    IF @@TRANCOUNT > 0 ROLLBACK TRAN;
END CATCH

SELECT * FROM Routes_Copy;
DROP TABLE IF EXISTS Routes_Copy;
SELECT * INTO Routes_Copy FROM Routes;

ALTER TABLE Routes_Copy
ADD CONSTRAINT PK_Routes_Copy PRIMARY KEY (Id);

DECLARE @point VARCHAR(32);

BEGIN TRY
    BEGIN TRAN;
    
    DELETE FROM Routes_Copy WHERE Lenght > 1000;

    SET @point = 'p1'; SAVE TRAN @point;

    INSERT INTO Routes_Copy VALUES (999, 1, 2, 950, '12:00');

    SET @point = 'p2'; SAVE TRAN @point;

    INSERT INTO Routes_Copy VALUES (999, 1, 2, 950, '12:00');  -- ������

    SET @point = 'p3'; SAVE TRAN @point;

    COMMIT TRAN;
    PRINT 'ok';
END TRY
BEGIN CATCH
    PRINT '������: �' + CAST(ERROR_NUMBER() AS VARCHAR(5)) + ' ' + ERROR_MESSAGE();

    IF @@TRANCOUNT > 0
    BEGIN
        PRINT '����������� �����: ' + @point;
        ROLLBACK TRAN @point;
        COMMIT TRAN;
    END;
END CATCH
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
BEGIN TRANSACTION;

SELECT COUNT(*) FROM Routes_Copy WHERE Distance > 500;

COMMIT;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
BEGIN TRANSACTION;

SELECT COUNT(*) FROM Routes_Copy WHERE Distance > 500;

-- T1
-- T2

SELECT '���������', COUNT(*) FROM Routes_Copy WHERE Distance > 500;

COMMIT;
-- A
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;

SELECT COUNT(*) FROM Routes_Copy WHERE Distance > 500;

-- T1

COMMIT;

-- T2
INSERT INTO Routes_Copy VALUES (999, 1, 2, 950, '12:00');

-- ����� ����������
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
BEGIN TRANSACTION;

SELECT COUNT(*) FROM Routes_Copy WHERE Distance > 500;

COMMIT;
-- A
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRANSACTION;

SELECT COUNT(*) FROM Routes_Copy WHERE Distance > 500;

-- T1

COMMIT;

-- T2

