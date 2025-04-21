declare @avgNote real = (select avg(PROGRESS.NOTE) from PROGRESS)

if @avgNote > 5
print 'good'
else 
print 'bad' 