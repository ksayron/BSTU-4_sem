create table ActiveRoutes(
ID int primary key,
RouteID int foreign key references Routes(RouteID),
DriverID int foreign key references Drivers(DriverID),
DepartureDate date,
DeliveryDate date,
DaysActive int
)