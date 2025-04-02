Select FirstCityID, Name
fROM Routes r inner join Cities c
on r.FirstCityID = c.CityId
WHERE Name like '%M%'