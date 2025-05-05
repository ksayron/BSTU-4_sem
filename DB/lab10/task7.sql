EXEC SP_HELPINDEX 'Drivers';
EXEC SP_HELPINDEX 'Routes';
EXEC SP_HELPINDEX 'Cities';
EXEC SP_HELPINDEX 'ActiveRoutes';

SELECT * INTO Routes_copy FROM Routes;

SELECT * FROM Routes_copy
WHERE PayRate BETWEEN 1000 AND 1200
ORDER BY PayRate;

CHECKPOINT;
DBCC DROPCLEANBUFFERS; 

CREATE CLUSTERED INDEX IX_Routes_Clustered ON Routes_copy (PayRate, Lenght);
DROP INDEX IX_Routes_Clustered ON Routes_copy;

CREATE INDEX IX_Routes_NonClustered ON Routes_copy (PayRate, Lenght);

DROP INDEX IX_Routes_NonClustered ON Routes_copy;

CREATE INDEX IX_Routes_Include ON Routes_copy (PayRate) INCLUDE (Lenght);

DROP INDEX IX_Routes_Include ON Routes_copy;

CREATE INDEX IX_Routes_FillFactor ON Routes_copy (PayRate)
WITH (FILLFACTOR = 80);
DROP INDEX IX_Routes_FillFactor ON Routes_copy;

