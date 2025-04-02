Select isnull(dr.Surname,'**')[PULPIT],RouteID
From ActiveRoutes ar Left Outer Join Drivers dr
on ar.DriverID = dr.DriverID