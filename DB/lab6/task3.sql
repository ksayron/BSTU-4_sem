select *
from (
	select case when note between 4 and 5 then '4-5'
	when note between 6 and 7 then '6-7'
	else '8-10'
	end [note_case],
	count(*)[count]
	from PROGRESS group by case
	when note between 4 and 5 then '4-5'
	when note between 6 and 7 then '6-7'
	else '8-10'
	end
	) as T
	order by case [note_case]
	when '4-5' then 3
	when '6-7' then 2
	else 1
	end