-- Города (Cities)
INSERT INTO Cities (CityId, Name)
VALUES 
(4, 'Malorita'),
(5, 'Grodno'),
(6, 'Paris'),
(7, 'Berlin'),
(8, 'Warsaw'),
(9, 'Brest'),
(10, 'St. Petersburg');

-- Водители (Drivers)
INSERT INTO Drivers (DriverID, Surname, Name, LastName, Experience)
VALUES 
(3, 'Shumerov', 'Gilgamesh', 'Velikovich', 10),
(4, 'Maya', 'Ish-Vak-Cha', 'Ahab', 10),
(5, 'Venom', 'Snake', 'Big-Bossovich', 7),
(6, 'Rome', 'Ceaser', 'Velikovich', 4),
(7, 'Greek', 'Perikl', 'Kulturovich', 6),
(8, 'Makedonski', 'Aleksandr', 'Zavoevatovich', 2),
(9, 'Japan', 'Hedze', 'Tokimunovich', 9),
(10, 'VKL', 'Yagaylo', 'Vladislavovich', 1);

-- Маршруты (Routes)
INSERT INTO Routes (RouteID, FirstCityID, SecondCityID, PayRate, Lenght)
VALUES 

(3, 1, 3, 1200, 900),
(4, 4, 5, 1500, 1100),
(5, 5, 6, 900, 600),
(6, 6, 7, 950, 650),
(7, 7, 8, 1100, 750),
(8, 8, 9, 1050, 720),
(9, 9, 10, 980, 680),
(10, 10, 1, 1300, 1000),
(11, 3, 6, 870, 580),
(12, 2, 8, 1020, 710),
(13, 4, 9, 1170, 880),
(14, 5, 1, 1250, 920),
(15, 7, 3, 910, 640);

-- Активные маршруты (ActiveRoutes)
INSERT INTO ActiveRoutes (ID, RouteID, DriverID, DepartureDate, DeliveryDate, DaysActive)
VALUES 
(3, 3, 3, '2025-03-05', '2025-03-06', 2),
(4, 4, 4, '2023-11-20', '2023-11-25', 6),
(5, 5, 5, '2025-02-01', '2025-02-03', 3),
(6, 6, 6, '2024-10-11', '2024-10-12', 2),
(7, 7, 7, '2025-03-22', '2025-03-24', 3),
(8, 8, 8, '2025-01-30', '2025-02-01', 3),
(9, 9, 9, '2025-04-05', '2025-05-05', 31),        
(10, 10, 10, '2024-08-18', '2024-08-30', 13),
(11, 11, 1, '2023-09-09', '2023-09-10', 2),
(12, 12, 2, '2024-06-14', '2024-07-04', 21),       
(13, 13, 3, '2025-05-12', '2025-05-13', 2),
(14, 14, 4, '2025-03-01', '2025-03-28', 28),       
(15, 15, 5, '2025-04-01', '2025-04-02', 2);
