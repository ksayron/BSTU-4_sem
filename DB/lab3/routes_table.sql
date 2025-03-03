create table Routes(
RouteID int primary key,
FirstCityID int foreign key references Cities(CityID),
SecondCityID int foreign key references Cities(CityID),
PayRate int,
Lenght int
)