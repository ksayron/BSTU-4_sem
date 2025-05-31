create procedure proc1 @type Nvarchar(20)
as
begin

select *  from AUDITORIUM where AUDITORIUM_TYPE =@type

end
go


exec proc1 @type = 'À '
