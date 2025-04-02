select *
from (
	select case when Experience between 1 and 3 then 'Noob'
	when Experience between 4 and 7 then 'Pro'
	else 'Hacker'
	end [note_case],
	count(*)[count]
	from Drivers group by case
	when Experience between 1 and 3 then 'Noob'
	when Experience between 4 and 7 then 'Pro'
	else 'Hacker'
	end
	) as T
	order by case [note_case]
	when 'Noob' then 3
	when 'Pro' then 2
	else 1
	end