declare @z real, @t real, @x real

select @t = 5,
@x = 6


if (@t > @x) set @z = POWER(SIN(@t), 2)
else if (@t < @x) set @z = 4 * (@t + @x)
else set @z = 1 - POWER(EXP(1), @x - 2)

select @z z