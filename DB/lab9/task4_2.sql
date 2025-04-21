declare @fullName char(100) = 'Макейчик Татьяна Леонидовна',
@initials char(4)

declare @spaceIndex int = charindex(' ', @fullName);
declare @newName char(100) = substring(@fullName, @spaceIndex+1, len(@fullname))

set @initials = substring(@newName, 1, 1) + '.'
+ substring(@newName, CHARINDEX(' ', @newName) + 1, 1) + '.'

print 'full - ' + @fullName
print 'short - '+ substring(@fullName,0, @spaceIndex+1 ) + @initials
